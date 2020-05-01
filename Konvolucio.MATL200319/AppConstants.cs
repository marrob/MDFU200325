namespace Konvolucio.MATL200319.Service
{
    using System;
    public class AppConstants
    {
        public const string ValueNotAvailable2 = "n/a";
        public const string InvalidFlieNameChar = "A file name can't contain any of flowing characters:";
        public const string SoftwareCustomer = "Konvolúció Bt.";
        public const string SoftwareTitle = "MCEL181123 - BATTERY CELL EMULATOR";
        public const string GenericTimestampFormat = "yyyy.MM.dd HH:mm:ss";
        public const string FileNameTimestampFormat = "yyMMdd_HHmmss";
        public const string FileFilter = "*.csv,*.mes,*.typ|*.csv;*.mes;*.typ|*.csv|*.csv|*.mes|*.mes|*.typ|*.mes";
        public const string NewLine = "\r\n";
        public const string CsvFileSeparator = ",";
        public static string AppLogPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Konvolucio.MATL200319.Service.Log.txt";
        public static string IoLogPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Konvolucio.MATL200319.IO.Log.txt";
    }
}
