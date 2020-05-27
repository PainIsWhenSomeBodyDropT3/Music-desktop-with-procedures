using Google.Apis.Auth.OAuth2;
using Google.Apis.Download;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using File = Google.Apis.Drive.v3.Data.File;

namespace Music.dao.impl
{
    class GoogleSongDao : IGoogleSongDao
    {
        private static readonly string[] Scopes = { DriveService.Scope.Drive };
        private static readonly string APPLICATION_NAME = "GdTest";
        private static readonly string FOLDER_ID = "1SLX_hTzxBY4ggM9tuBq4J7xVXONbtFlr";
        private static readonly string CONTENT_TYPE = "audio/mpeg";
        private static readonly string DOWNLOAD_FILE_PATH = @"D:\music_from_cursach\";
        private static string FileName {get;set; }
        private static string FilePath {get; set; }
       
       
        private static string FullDowloadFilePath { get; set; }

      
        private static UserCredential GetUserCredential()
        {
            using (var stream = new FileStream("client_secret.json", FileMode.Open, FileAccess.Read))
            {
                string creadPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                creadPath = Path.Combine(creadPath, "driveApiCredentials", "drive-credentials.json");
                return GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,
                    "User",
                    CancellationToken.None,
                    new FileDataStore(creadPath, true)).Result;

            }
        }
        private static DriveService GetDriveService(UserCredential credential)
        {
            return new DriveService(
                new BaseClientService.Initializer
                {
                    HttpClientInitializer = credential,
                    ApplicationName = APPLICATION_NAME

                }
                );
        }

        private static string UploadFileToDrive(DriveService service, string fileName, string filePath, string contentType)
        {
            var fileMataData = new File();
            fileMataData.Name = fileName;
            fileMataData.Parents = new List<string> { FOLDER_ID };

            FilesResource.CreateMediaUpload request;
            using (var stream = new FileStream(filePath, FileMode.Open))
            {
                request = service.Files.Create(fileMataData, stream, contentType);
                request.Upload();
            }
            var file = request.ResponseBody;
            return file.Id;
        }

        private static void DownloadFileFromDrive(DriveService service, string fileId, string filePath)
        {
            var request = service.Files.Get(fileId);
           
            using (var memoryStream = new MemoryStream())
            {
                request.MediaDownloader.ProgressChanged += (IDownloadProgress progress) =>
                {
                    switch (progress.Status)
                    {
                        case DownloadStatus.Downloading:
                            {
                                break;
                            }
                        case DownloadStatus.Completed:
                            {
                                break;
                            }
                        case DownloadStatus.Failed:
                            {
                                break;
                            }
                    }
                };
                request.Download(memoryStream);


                using (var fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                {
                    fileStream.Write(memoryStream.GetBuffer(), 0, memoryStream.GetBuffer().Length);
                }
            }
        }
        public void create(Song t)
        {
            ISongDao songDao = DaoFactory.getInstance().GetSongDao();

            UserCredential credential = GetUserCredential();

            DriveService service = GetDriveService(credential);

            t.LocalUrl = UploadFileToDrive(service, t.Name, FilePath, CONTENT_TYPE);

            songDao.create(t);

           
        }

        public void delete(Song t)
        {
            UserCredential credential = GetUserCredential();

            DriveService service = GetDriveService(credential);

            var request1 = service.Files.Delete(t.LocalUrl);

            request1.Execute();
        }

        public Song readById(int id)
        {
            ISongDao songDao = DaoFactory.getInstance().GetSongDao();
            UserCredential credential = GetUserCredential();

            DriveService service = GetDriveService(credential);
            Song song = songDao.readById(id);
            FullDowloadFilePath = DOWNLOAD_FILE_PATH + song.Name+".mp3";
            DownloadFileFromDrive(service, song.LocalUrl, FullDowloadFilePath);
            return song;
        }

        public Song update(int id, Song t)
        {
            throw new NotImplementedException();
        }

        public void setFilePath(string filePath)
        {
            FilePath = filePath;
        }

        public string getFullDownloadFilePath()
        {
            return FullDowloadFilePath;
        }
    }
}
