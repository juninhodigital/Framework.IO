using System;
using System.IO;
using System.Text;

namespace Framework.IO
{
    /// <summary>
    /// Provides methods that handles with File System operations
    /// </summary>
    public sealed class IO
    {
        #region| Methods |

        /// <summary>
        /// Check if a file is been used by another process
        /// </summary>
        /// <param name="FilePath">Full File Path</param>
        /// <returns>bool</returns>
        public static bool IsFileUsedbyAnotherProcess(string FilePath)
        {
            try
            {
                var oFile = File.Open(FilePath, FileMode.Open, FileAccess.ReadWrite, FileShare.None);

                oFile.Flush();
                oFile.Close();

                oFile.Dispose();

            }
            catch (System.IO.IOException)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Opens a file, reads all lines of the file with the specified encoding, and then closes the file.
        /// </summary>
        /// <param name="Path">The file to open for reading.</param>
        /// <returns> A string containing all lines of the file.</returns>
        public static string ReadFile(string Path)
        {
            var Result = string.Empty;

            try
            {
                if (!string.IsNullOrEmpty(Path))
                {
                    if (!string.IsNullOrEmpty(Path))
                    {
                        if (File.Exists(Path))
                        {
                            Result = File.ReadAllText(Path, Encoding.GetEncoding("ISO-8859-1"));
                        }
                        else
                        {
                            Result = "FRAMEWORK: Arquivo não existe no caminho especificado.";
                        }
                    }
                    else
                    {
                        Result = "FRAMEWORK: Caminho do arquivo está vazio.";
                    }
                }
            }
            catch (System.Exception oError)
            {
                Result = "FRAMEWORK: Ocorreu um erro ao ler o arquivo." + oError.Message;
            }

            return Result;


        }

        /// <summary>
        ///  Creates a System.IO.StreamWriter that appends UTF-8 encoded text to an existing file.
        /// </summary>
        /// <param name="Path">The path to the file to append to.</param>
        /// <param name="Content">The string to append to the file.</param>
        public static void AppendFile(string Path, string Content)
        {
            try
            {
                if (!string.IsNullOrEmpty(Path))
                {
                    if (!string.IsNullOrEmpty(Path))
                    {
                        File.AppendAllText(Path, Content, Encoding.GetEncoding("ISO-8859-1"));
                    }
                    else
                    {
                        throw new Exception("Framework: Caminho do arquivo está vazio.");
                    }
                }
            }
            catch (System.Exception oError)
            {
                throw new Exception("Framework: Ocorreu um erro ao ler o arquivo." + oError.Message);
            }
        }

        #endregion
    }
}
