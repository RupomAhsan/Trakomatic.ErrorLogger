namespace ErrorLogger.Interfaces
{
    public interface IArchive
    {
        void ArchiveLogFile();

        bool CheckArchiveFolderExists();

        void CreateArchiveFolder();
    }
}