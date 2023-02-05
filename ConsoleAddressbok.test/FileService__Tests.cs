using ConsoleAddressbok.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAddressbok.test
{
    public class FileServiceTest
    {
        FileService fileService;
        string content; public FileServiceTest()
        {
            // arrange
            fileService = new FileService();
            fileService.FilePath = $@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\contentTest.json";
            content = JsonConvert.SerializeObject(new { FirstName = "Oskar", LastName = "LinkStrom", Email = "Orre@balalabla.com"});
        }
        [Fact]
        public void Should_Create_a_File_With_Json_Content()
        {
            // act
            fileService.Save(fileService.FilePath, content);
            string result = fileService.Read(fileService.FilePath);
            // assert
            Assert.True(File.Exists(fileService.FilePath));
            Assert.Equal(result.Trim(), content);
        }
    }
}
