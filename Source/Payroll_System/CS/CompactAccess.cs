using System;
using System.Windows.Forms;

namespace Payroll_System
{
    class CompactAccess : DbBase
    {
        /// <summary>

        /// MBD compact method (c) 2004 Alexander Youmashev

        /// !!IMPORTANT!!

        /// !make sure there's no open connections

        ///    to your db before calling this method!

        /// !!IMPORTANT!!

        /// </summary>

        /// <param name="connectionString">connection string to your db</param>

        /// <param name="mdwfilename">FULL name

        ///     of an MDB file you want to compress.</param>

        public static string CompactAccessDB(string startupPath)
        {
            string msg = string.Empty;

            object[] oParams;

            //create an inctance of a Jet Replication Object

            try
            {
                object objJRO =

                    Activator.CreateInstance(Type.GetTypeFromProgID("JRO.JetEngine"));



                //filling Parameters array

                //cnahge "Jet OLEDB:Engine Type=5" to an appropriate value

                // or leave it as is if you db is JET4X format (access 2000,2002)

                //(yes, jetengine5 is for JET4X, no misprint here)


                DbBase AccessDB = new DbBase();
                AccessDB._startupPath = startupPath;
                AccessDB.joinDBString();
                AccessDB.joinBackupString();

                if (!System.IO.Directory.Exists(AccessDB._backupPath))
                {
                    DialogResult result = MessageBox.Show("Backup folder does not exist? Create it now ? ", "Create backup folder", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        System.IO.Directory.CreateDirectory(AccessDB._backupPath);
                    }
                }

                if (System.IO.File.Exists(AccessDB.BackupAbsFile))
                {
                    System.IO.File.Delete(AccessDB.BackupAbsFile);
                }

                //oParams = new object[] {  connectionString, "Provider=Microsoft.Jet.OLEDB.4.0;Data" + " Source=C:\\tempdb.mdb;Jet OLEDB:Engine Type=5"};

                oParams = new object[] { AccessDB.ConnectionString, AccessDB.BackupConnectionString };


                //invoke a CompactDatabase method of a JRO object

                //pass Parameters array

                objJRO.GetType().InvokeMember("CompactDatabase",

                    System.Reflection.BindingFlags.InvokeMethod,

                    null,

                    objJRO,

                    oParams);


                AccessDB.setDBPassWord();

                //database is compacted now

                //to a new file C:\\tempdb.mdb

                //let's copy it over an old one and delete it



                //System.IO.File.Delete(mdwfilename);

                //System.IO.File.Move("C:\\tempdb.mdb", mdwfilename);



                //clean up (just in case)

                System.Runtime.InteropServices.Marshal.ReleaseComObject(objJRO);

                objJRO = null;
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }

            return msg;
        }

        public static string RecoverAccessDB(string startupPath, string sourceBackupDB)
        {
            string msg = string.Empty;

            try
            {
                DbBase AccessDB = new DbBase();
                AccessDB._startupPath = startupPath;
                AccessDB.joinDBString();
                AccessDB.joinBackupString();

                if (System.IO.File.Exists(AccessDB.PayrollAbsFile))
                {
                    System.IO.File.Delete(AccessDB.PayrollAbsFile);
                }

                System.IO.File.Copy(sourceBackupDB, AccessDB.PayrollAbsFile);

            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }

            return msg;
        }
    }
}
