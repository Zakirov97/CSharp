using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TemplateEngine.Docx;

namespace CountryReference
{
    #region Containes
    public class Currency
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public object Symbol { get; set; }
    }

    public class Language
    {
        public string Name { get; set; }
        public string NativeName { get; set; }
    }

    public class CountryDto
    {
        public string Name { get; set; }
        public List<string> TopLevelDomain { get; set; }
        public string Alpha2Code { get; set; }
        public string Alpha3Code { get; set; }
        public List<string> CallingCodes { get; set; }
        public string Capital { get; set; }
        public List<string> AltSpellings { get; set; }
        public string Region { get; set; }
        public string Subregion { get; set; }
        public int Population { get; set; }
        public string Demonym { get; set; }
        public double Area { get; set; }
        public List<string> Timezones { get; set; }
        public List<string> Borders { get; set; }
        public string NativeName { get; set; }
        public string NumericCode { get; set; }
        public List<Currency> Currencies { get; set; }
        public List<Language> Languages { get; set; }
        public string Flag { get; set; }
    }

    #endregion

    class CountryRepository
    {
        private readonly string CountryFolder = @"C:\Countries";
        public void Save(CountryDto dto)
        {
            Directory.CreateDirectory(CountryFolder);
            DirectoryInfo di = new DirectoryInfo(CountryFolder);

            DirectoryInfo country = di.CreateSubdirectory(dto.Name);
            string fileName = country.FullName + @"\" + dto.Name + ".json";
            string imageName = country.FullName + @"\" + dto.Name + ".svg";

            string content = JsonConvert.SerializeObject(dto);

            File.WriteAllText(fileName, content);
            GenerateDocReport(dto);
            SaveImage(dto, imageName);
        }

        private void GenerateDocReport(CountryDto dto)
        {

            DirectoryInfo di = new DirectoryInfo(CountryFolder);

            DirectoryInfo country = di.CreateSubdirectory(dto.Name);

            string reportName = country.FullName + @"\" + dto.Name + ".docx";

            File.Copy(@"C:\Countries\CountryReportTemplate.docx", 
                $@"C:\Countries\{dto.Name}\{dto.Name}.docx");

            var valuesToFill = new Content(
                new FieldContent("CountryNamePlaceholder", dto.Name));

            using (var outputDocument = new TemplateProcessor($@"C:\Countries\{dto.Name}\{dto.Name}.docx")
                .SetRemoveContentControls(true))
            {
                outputDocument.FillContent(valuesToFill);
                outputDocument.SaveChanges();
            }
        }
        private void SaveImage(CountryDto dto, string pathToSave)
        {
            WebClient webClient = new WebClient();
            webClient.DownloadFile(dto.Flag, pathToSave);
        }
    }
    class CountryService
    {
        private ApiProvider<CountryDto> _apiProvider;
        private IEnumerable<string> GetCountryCodes()
        {
            var countries = CultureInfo.GetCultures(CultureTypes.SpecificCultures)
                .Select(x => new RegionInfo(x.LCID))
                .Select(x => x.ThreeLetterISORegionName)
                .Distinct()
                .OrderBy(x => x);

            return countries;
        }

        public IEnumerable<CountryDto> GetCountries()
        {
            var allCodes = GetCountryCodes();
            try
            {
                var result = allCodes
                    .Select(p => _apiProvider.Get(p))
                    .OfType<CountryDto>();

                return result;
            }
            catch(Exception ex)
            {
                throw;
            }
        }
        public CountryService(ApiProvider<CountryDto> apiProvider)
        {
            _apiProvider = apiProvider;
        }
    }

    class ApiProvider<T> where T : class
    {
        private string _urlPath;
        public T Get(string requestUrl)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(_urlPath);
            try
            {
                string response = httpClient.GetStringAsync(requestUrl).Result;
                if (response != null)
                {
                    try
                    {
                        return JsonConvert.DeserializeObject<T>(response);
                    }
                    catch (Exception ex) { throw; }
                }
                else throw new Exception();
            }
            catch (Exception ex)
            {
                return null;
            }                              
        }
        public ApiProvider(string urlPath)
        {
            _urlPath = urlPath;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ApiProvider<CountryDto> api = new ApiProvider<CountryDto>("https://restcountries.eu/rest/v2/alpha/");
            CountryService cs = new CountryService(api);
            CountryRepository repo = new CountryRepository();

            foreach (var item in cs.GetCountries())
            {
                repo.Save(item);
            }
            Console.ReadLine();
        }
    }
}
