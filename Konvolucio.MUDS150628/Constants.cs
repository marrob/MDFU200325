namespace Konvolucio.MUDS150628
{
    using System;
    public class Constants
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
        public static string LogPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Konvolucio.MATL200319.IO.Log.txt";
    }
}
