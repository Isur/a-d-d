using System;
using System.Diagnostics;
using System.IO;

namespace Common
{
    /// <summary>
    /// Klasa odpowiedzialna za zarządzanie plikiem logowania.
    /// </summary>
    public static class Logger
    {
        /// <summary>
        /// Nazwa pliku logowania.
        /// </summary>
        public static readonly string FileName = "Logs.txt";
        /// <summary>
        /// Nazwa folderu archiwizacji.
        /// </summary>
        public static readonly string DirectoryName = "archives";
        /// <summary>
        /// Ścieżka do folderu, w którym zjaduje się system PBL.
        /// </summary>
        public static readonly string DirectoryPath = AppDomain.CurrentDomain.BaseDirectory + "/";
        /// <summary>
        /// Całkowita ścieżka do pliku logowania.
        /// </summary>
        public static readonly string FilePath = DirectoryPath + FileName;

        /// <summary>
        /// Maksymalna wielkość pliku logowania w MB (1MB to BARDZO duża ściana tekstu).
        /// </summary>
        public static readonly double MaxLogSize = 1.0f;

        /// <summary>
        /// Obiekt zawierający informacje o pliku logowania (potrzebny do sprawdzania rozmiaru pliku).
        /// </summary>
        public static FileInfo FileInfo { get; private set; } = new FileInfo(FilePath);
        /// <summary>
        /// Rozmiar pliku logowania w MB.
        /// </summary>
        public static double FileSize
        {
            get
            {
                FileInfo.Refresh();
                return FileInfo.Length / (1024.0f * 1024.0f);
            }
        }

        /// <summary>
        /// Zapisuje błąd do pliku logowania.
        /// </summary>
        /// <param name="message"></param>
        public static void Error(object message)
        {
            msg(message, LogType.ERROR);
        }
        /// <summary>
        /// Zapisuje informacje do pliku logowania.
        /// </summary>
        /// <param name="message"></param>
        public static void Info(object message)
        {
            msg(message, LogType.INFO);
        }
        /// <summary>
        /// Zapisuje ostrzeżenie do pliku logowania.
        /// </summary>
        /// <param name="message"></param>
        public static void Warning(object message)
        {
            msg(message, LogType.WARNING);
        }
        /// <summary>
        /// Zapisuje błąd krytyczny do pliku logowania.
        /// </summary>
        /// <param name="message"></param>
        public static void Fatal(object message)
        {
            msg(message, LogType.FATAL);
        }
        /// <summary>
        /// Zapisuje nową linię do pliku logowania.
        /// </summary>
        public static void NewLine()
        {
            try
            {
                using (StreamWriter writer = File.AppendText(FilePath))
                {
                    writer.WriteLine(" ");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Tworzy pojedynczy wpis do logu z informacją o DACIE i TYPIE WPISYWANEJ WIADOMOŚCI.
        /// Jeśli plik logowania przekroczy maksymalną wielkość to zostanie zarchiwizowany, a następnie całkowicie wyczyszczony z danych.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="type"></param>
        private static void msg(object message, LogType type)
        {
            string space = string.Empty;
            if (type == LogType.ERROR || type == LogType.FATAL) space = "  ";
            else if (type == LogType.INFO) space = "   ";

            try
            {
                using (StreamWriter writer = File.AppendText(FilePath))
                {
                    writer.WriteLine(DateTime.Now + "   " + type + "   " + space + createLogMessage(message));
                }

                FileInfo.Refresh();
                if (FileSize >= MaxLogSize)
                    Backup();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        /// <summary>
        /// Tworzy właściwą wiadomość wpisu dodając do niej informacje o klasie i metodzie w której zapis został wykonany.
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        private static string createLogMessage(object message)
        {
            StackFrame frame = new StackFrame(3);
            var method = frame.GetMethod();
            var type = method.DeclaringType.Name;
            var methodName = method.Name;

            var logMessage = type + "." + methodName + " - " + message;

            return logMessage;
        }

        /// <summary>
        /// Wykonuje archiwizacje pliku logowania.
        /// Nazwą zarchiwizowanego pliku będzie data archiwizacji.
        /// </summary>
        public static void Backup()
        {
            Backup(DateTime.Now.ToString().Replace(':', '.'));
        }
        /// <summary>
        /// Wykonuje archiwizacje pliku logowania.
        /// </summary>
        /// <param name="newName"></param>
        public static void Backup(object newName)
        {
            try
            {
                if (!Directory.Exists(DirectoryPath + DirectoryName))
                    Directory.CreateDirectory(DirectoryPath + DirectoryName);

                File.Copy(FilePath, DirectoryPath + DirectoryName + "/" + newName + ".txt");
                ClearLog();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        /// <summary>
        /// Czyści plik logowania z danych.
        /// </summary>
        public static void ClearLog()
        {
            File.WriteAllText(FilePath, string.Empty);
        }
    }
}
