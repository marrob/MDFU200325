﻿namespace Konvolucio.MDFU200325
{
    using System;
    public class AppConstants
    {
        public const string ValueNotAvailable2 = "n/a";
        public const string InvalidFlieNameChar = "A file name can't contain any of flowing characters:";
        public const string SoftwareCustomer = "Konvolúció Bt.";
        public const string SoftwareTitle = "MDFU200325 - MATL Device Firmware Updater CLIENT";
        public const string GenericTimestampFormat = "yyyy.MM.dd HH:mm:ss";
        public const string FileNameTimestampFormat = "yyMMdd_HHmmss";
        public const string FileFilter = "Binary File(*.bin)|*.bin";
        public const string NewLine = "\r\n";
        public const string CsvFileSeparator = ",";
        public static string LogPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Konvolucio.MATL200319.IO.Log";
    }
}
