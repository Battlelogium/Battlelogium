using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using Microsoft.Win32;


namespace ParManager
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0) return;
            if (args[0] == "remove") Program.RemoveOriginRequirement();
            if (args[0] == "restore") Program.RestoreOriginRequirement();
        }
        public static void RemoveOriginRequirement()
        {
            string parFile = @"KgIRPFYyKXkDLQJfVBsPIngUDiNYHSUgLkcHAwhKDXtqSRwEO1YIKzNUHykTKmsfQlYBexNTUBID
                                PGMSWSFUASwfNh04SltZfB1iSic2EkYYGwFtMykeE3YNSkYfEghYVwcLPF8UBTVDHioVLEczV10D
                                PCVpVBIYJEotMCR8NB81DnIMQFAZPR1aTRBHIEEYAQRFFG4bKkplbEcDKQdfSBY6MUcZV1gRMnos
                                IlwBSFATEhdTShoJNWsBFgZaRBIVO1IGT2UJYAVTVB8FKR0mHgsCQxwkIWczb1oJLy1qYgEFI0cI
                                KyxfBSUCIlYLSlQeKx1hbT1ZYmw2Nih0LhM/GmEsZmkvDAhlcSw4H3wlKwdXQm4VN1Zlb1oLKiRE
                                YhoGNWMQAw0RTGBSDAkzTloEJSRPeCUPPloSEj1BECMbemEKV1QDIhFVCjcPIF8eDktmGC5DfW87
                                TWE2DDRfSBc2ElofKyBTGDMFE3oBUEELIi1TViMYP1kUFBFtBSgZPVcwU1QYOjhqYzInFWw0NiRS
                                EiUDPG84UVQaPihYQ1M+P1wdBDl9HiEUKkE8V0AIEQ9XUBocNR0UDwATexcCLkMfRlEsJy1TdBIe
                                OBNMVyYLLS0fIVgKWmk8Ky9fRxYyIFISHFBjFDQRJl8/QBsuKzFaSwpEB1ofRFdtJS4kE38AQFQG
                                EgdESwAeKW84GRFUAy0VK1oOV1A2GQh4F0E1F3I8MjpiPhUiDHYzZncjHRRpayY+AGYlKxFcASYZ
                                I1Ycf0EHPiRXRRAJNUACKwdXQm4VN1ZlYFoEOiRYUDoOcA5RQFUHQHlceAJfFQJGCgZkFEJcYApD
                                Q1EdNQcifwJZEwxYenQ8dAEFNEYSAzZFBCQZIBNSAxcvD2FxRR4PIxF7JxdeFTUTO2cGV1kPbnwW
                                BjELJEcdEgNYFCwUbwBNKWUYISVDRwcjNBNMVyFjS3JCegNZFwRafktmVhwANVAFPgERTGBDfwNd
                                GgFgBy9FUBIGPFYVMwxCBTIfbw5PYlYJKzJFYBoNOUcQGzMCexMFP0MAUUEPKgVfVwcYP0BRSkVw
                                EiMVPEArSlIDOiBackBg
                                ";

            string bf3Path = "";
            try
            {
                bf3Path = GetBF3Path();
            }
            catch
            {
                MessageBox.Show("Battlefield 3 Not Found");
                Environment.Exit(1);
                return;
            }
            string parPath = Path.Combine(bf3Path, "bf3.par");
            string origPar = Path.Combine(bf3Path, "bf3.par.orig");
            if (!File.Exists(origPar))
            {
                try
                {
                    File.Move(parPath, origPar);
                    File.WriteAllBytes(parPath, Convert.FromBase64String(parFile));
                    Environment.Exit(0);
                    return;
                }
                catch (Exception)
                {
                    MessageBox.Show("Error while removing Origin requirement");
                    Environment.Exit(1);
                    return;
                }
            }

        }

        public static void RestoreOriginRequirement()
        {
            string bf3Path;
            try
            {
                bf3Path = GetBF3Path();
            }
            catch
            {
                MessageBox.Show("Battlefield 3 Not Found");
                Environment.Exit(1);
                return;
            }
            if (!File.Exists(Path.Combine(bf3Path,"bf3.par.orig")))
            {
                MessageBox.Show("Origin Requirement Already Present");
                Environment.Exit(1);
                return;
            }
            try
            {
                File.Delete(Path.Combine(bf3Path, "bf3.par"));
                File.Move(Path.Combine(bf3Path, "bf3.par.orig"), Path.Combine(bf3Path, "bf3.par"));
                Environment.Exit(0);
                return;
            }
            catch (Exception)
            {
                MessageBox.Show("Error occured when restoring Origin requirement");
                Environment.Exit(1);
                return;
            }
        }

        private static string GetBF3Path()
        {
            string bf3Path;
            try
            {
                if (Environment.Is64BitOperatingSystem)
                {
                    bf3Path =
                        Registry.GetValue(
                            @"HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\EA Games\Battlefield 3", "Install Dir", "").ToString();
                }
                else
                {
                    bf3Path =
                        Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\EA Games\Battlefield 3", "Install Dir", "").ToString();
                }
                if (bf3Path == "") throw new Exception(); //throw if BF3 path not found
                return bf3Path;
            }
            catch (Exception)
            {
                throw new FileNotFoundException("Battlefield 3 not found");
            }
        }
    }
}
