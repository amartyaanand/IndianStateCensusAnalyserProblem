using CensusAnalyserLive.POCO;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using CensusAnalyserLive;
using static CensusAnalyserLive.CensusAnalyser;

namespace CensusAnalyserTestLive
{
    class CensusAnalyserTest
    {
        static readonly string indianStateCensusHeaders = "State,Population,AreaInSqKm,DensityPerSqKm";
        static readonly string indianStateCensusFilePath = @"D:\GitBash\IndianStateCensusAnalyserProblem\CensusAnalyserTestLive\CSVFiles\IndiaStateCensusData.csv";
        static readonly string indianStateWrongFilePath = @"WrongIndiaStateCensusData.csv";
        static readonly string indianStateWrongTypeFilePath = @"D:\GitBash\IndianStateCensusAnalyserProblem\CensusAnalyserTestLive\CSVFiles\IndiaStateCensusData.txt";
        static readonly string indianStateIncorrectDelimiterFilePath = @"D:\GitBash\IndianStateCensusAnalyserProblem\CensusAnalyserTestLive\CSVFiles\DelimiterIndiaStateCensusData.csv";
        static readonly string indianStateIncorrectHeaderFilePath = @"D:\GitBash\IndianStateCensusAnalyserProblem\CensusAnalyserTestLive\CSVFiles\WrongIndiaStateCensusData.csv";
        CensusAnalyser censusAnalyser;
        Dictionary<string, CensusDTO> totalRecord;
        Dictionary<string, CensusDTO> stateRecord;
        [SetUp]
        public void Setup()
        {
            censusAnalyser = new CensusAnalyser();
            totalRecord = new Dictionary<string, CensusDTO>();
            stateRecord = new Dictionary<string, CensusDTO>();
        }
        [Test]
        public void GivenIndianCensusDataFile_WhenReaded_ShouldReturnCensusDataCount()
        {
            totalRecord = censusAnalyser.LoadCensusData(Country.INDIA, indianStateCensusFilePath, indianStateCensusHeaders);
            Assert.AreEqual(29, totalRecord.Count);
        }
        [Test]
        public void GivenIndianCensusDataFile_IfIncorret_ShouldThrowCustomException()
        {
            try
            {
                totalRecord = censusAnalyser.LoadCensusData(Country.INDIA, indianStateWrongFilePath, indianStateCensusHeaders);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual("File Not Found", e.Message);
            }
        }
        [Test]
        public void GivenIndianCensusDataFile_TypeIncorret_ShouldThrowCustomException()
        {
            try
            {
                totalRecord = censusAnalyser.LoadCensusData(Country.INDIA, indianStateWrongTypeFilePath, indianStateCensusHeaders);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual("Invalid File Type", e.Message);
            }
        }
        [Test]
        public void GivenIndianCensusDataFile_IncorrectDelimiter_ShouldThrowCustomException()
        {
            try
            {
                totalRecord = censusAnalyser.LoadCensusData(Country.INDIA, indianStateIncorrectDelimiterFilePath, indianStateCensusHeaders);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual("File Contains Wrong Delimiter", e.Message);
            }
        }
        [Test]
        public void GivenIndianCensusDataFile_WrongHeader_ShouldThrowCustomException()
        {
            try
            {
                totalRecord = censusAnalyser.LoadCensusData(Country.INDIA, indianStateIncorrectHeaderFilePath, indianStateCensusHeaders);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual("Incorrect header in Data", e.Message);
            }
        }
    }
}
