using System.Net;

    class Program
    {
        static async Task Main(string[] args)
        {
            // Prompt user to input URL
            Console.WriteLine("Enter the URL:");
            string url = Console.ReadLine();
            string file = "A.txt";

            try
            {
                // Call the method to download content from URL and write to file asynchronously
                await DownloadAndWriteAsync(url, file);
                Console.WriteLine("Content has been downloaded and written to the file successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        // Method to download content from URL and write to file asynchronously
        static async Task DownloadAndWriteAsync(string url, string file)
        {
            using (var client = new WebClient())
            {
                string content = await client.DownloadStringTaskAsync(url);

                using (StreamWriter writer = File.CreateText(file))
                {
                    await writer.WriteAsync(content);
                }
            }
        }
    }