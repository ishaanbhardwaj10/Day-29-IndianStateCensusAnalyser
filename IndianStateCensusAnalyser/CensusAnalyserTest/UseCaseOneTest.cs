using IndianStateCensusAnalyser;
using IndianStateCensusAnalyser.DTO;
using static IndianStateCensusAnalyser.CensusAnalyser;

namespace CensusAnalyserTest
{
    public class Tests
    {


        static string indianStateCensusHeaders = "State,Population,AreaInSqKm,DensityPerSqKm";
        
        static string indianStateCensusFilePath = @"C:\Users\ishaa\Documents\ZNewFolder\Day-29-IndianStateCensusAnalyser\IndianStateCensusAnalyser\CensusAnalyserTest\CsvFiles\IndiaStateCensusData.csv";
        static string wrongIndianStateCensusFilePath = @"C:\Users\ishaa\Documents\ZNewFolder\Day-29-IndianStateCensusAnalyser\IndianStateCensusAnalyser\CensusAnalyserTest\CsvFiles\EndiaStateCensusData.csv";
        static string wrongIndianStateCensusFileType = @"C:\Users\ishaa\Documents\ZNewFolder\Day-29-IndianStateCensusAnalyser\IndianStateCensusAnalyser\CensusAnalyserTest\CsvFiles\IndiaStateCensusData.txt";
        static string delimiterIndianCensusFilePath = @"C:\Users\ishaa\Documents\ZNewFolder\Day-29-IndianStateCensusAnalyser\IndianStateCensusAnalyser\CensusAnalyserTest\CsvFiles\DelimiterIndiaStateCensusData.csv";
        static string wrongHeaderIndianCensusFilePath = @"C:\Users\ishaa\Documents\ZNewFolder\Day-29-IndianStateCensusAnalyser\IndianStateCensusAnalyser\CensusAnalyserTest\CsvFiles\WrongIndiaStateCensusData.csv";


        CensusAnalyser censusAnalyser;
        Dictionary<string, CensusDTO> totalRecord;

        [SetUp]
        public void Setup()
        {
            censusAnalyser = new CensusAnalyser();
            totalRecord = new Dictionary<string, CensusDTO>();
        }


        //TC-1.1
        [Test]
        public void GivenIndianCensusDataFile_WhenRead_ShouldReturnCensusDataCount()
        {
            totalRecord = censusAnalyser.LoadCensusData(indianStateCensusFilePath, Country.INDIA, indianStateCensusHeaders);
            Assert.AreEqual(29, totalRecord.Count);
        }


        //TC-1.2
        [Test]
        public void GivenWrongIndianCensusDataFile_WhenRead_ShouldReturnCustomException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(wrongIndianStateCensusFilePath, Country.INDIA, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, censusException.eType);
        }

        
        //TC-1.3
        [Test]
        public void GivenWrongIndianCensusDataFilePath_WhenRead_ShouldReturnCustomException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(wrongIndianStateCensusFileType, Country.INDIA, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE, censusException.eType);
        }


        //TC-1.4
        [Test]
        public void GivenWrongDelimiterIndianCensusDataFile_WhenRead_ShouldReturnCustomException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(delimiterIndianCensusFilePath, Country.INDIA, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER, censusException.eType);
        }


        //TC-1.5
        [Test]
        public void GivenWrongHeaderIndianCensusDataFile_WhenRead_ShouldReturnCustomException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(wrongHeaderIndianCensusFilePath, Country.INDIA, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, censusException.eType);
        }

    }
}