using Dataformatter.Datamodels;
using Dataformatter.Dataprocessing.Parsing;
using Dataformatter.Dataprocessing.Processors;
using Dataformatter.Data_accessing.Factories.ModelFactories;
using Dataformatter.Data_accessing.Repositories;

namespace Repository
{
    public static class RepositoryHub
    {
        public static CountryBordersRepository CountryBordersRepository;
        public static Iso3166Country[] Iso3166Countries;
        

        public static void Init()
        {
            //Parsing
            SetDataPaths();
            Iso3166Repository.InitializeCollection();
            
            //Countries
            ParseCountryBorders();
            CountryBordersRepository = new CountryBordersRepository();
            Iso3166Countries = Iso3166Repository.GetCollection();
        }

        private static void SetDataPaths()
        {
            Dataformatter.Paths.SetProcessedDataFolder(@"E:\Hogeschool\Polishift Organization\ProcessedData\");
            Dataformatter.Paths.SetRawDataFolder(@"E:\Hogeschool\Polishift Organization\ProcessedData\CountryInformation");
        }

        private static void ParseCountryBorders()
        {
            var geoModelFactory = new CountryGeoModelFactory();
            var countryGeoJsonPath = Dataformatter.Paths.RawDataFolder;

            var countryBorderModels = JsonToModel<CountryGeoModel>.ParseJsonDirectoryToModels(countryGeoJsonPath,
                geoModelFactory,
                "*.geo.json");

            var countryBordersProcessor = new CountryBordersProcessor();
            countryBordersProcessor.SerializeDataToJson(countryBorderModels);
        }
    }
}