using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShippingRoutes;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitShippingRoutes
    {
        ShippingRoutes.City BuenosAires, NewYork, Liverpool, Casablanca, CapeTown;

        [TestInitialize]
        public void StartUp()
        {
            // Initialise city names
            BuenosAires = new City("Buenos Aires");
            NewYork = new City("New York");
            Liverpool = new City("Liverpool");
            Casablanca = new City("Casablanca");
            CapeTown = new City("Cape Town");

            // Initialise connections
            BuenosAires.Connections = new Route[3]{ 
                new Route(NewYork, 6) , 
                new Route(Casablanca, 5), 
                new Route(CapeTown, 4)
            };

            NewYork.Connections = new Route[1] {
                new Route(Liverpool, 4)
            };

            Liverpool.Connections = new Route[2] {
                new Route(Casablanca, 3),
                new Route(CapeTown, 6)
            };

            Casablanca.Connections = new Route[2] {
                new Route(Liverpool, 3),
                new Route(CapeTown, 6)
            };

            CapeTown.Connections = new Route[1] {
                new Route(NewYork, 8)
            };
        }

        /// <summary>
        /// Test Journey From Buenos Aires Via New York To Liverpool
        /// </summary>
        [TestMethod]
        public void TestJourneyFromBuenosAiresViaNewYorkToLiverpool()
        {
            Assert.IsTrue(SearchAlgorithm.IsValidRoute(BuenosAires, Liverpool));
            Assert.AreEqual(10, SearchAlgorithm.FindRoute(BuenosAires, Liverpool));

            Assert.IsTrue(SearchAlgorithm.FindNextLeg(
                new Route[2]{
                    new Route(NewYork, 6),
                    new Route(Liverpool, 4) 
                },
                0,
                Liverpool,
                BuenosAires));

            Assert.AreEqual(10, SearchAlgorithm.FindNextLegDistance(
                new Route[2]{
                    new Route(NewYork, 6),
                    new Route(Liverpool, 4) 
                },
                0,
                Liverpool,
                BuenosAires));
        }

        /// <summary>
        /// Test Journey From Buenos Aires Via Casablanca To Liverpool
        /// </summary>
        [TestMethod]
        public void TestJourneyFromBuenosAiresViaCasablancaToLiverpool()
        {
            Assert.IsTrue(SearchAlgorithm.FindNextLeg(
                new Route[2]{
                                new Route(Casablanca, 5),
                                new Route(Liverpool, 3) 
                            },
                0,
                Liverpool,
                BuenosAires));

            Assert.AreEqual(8, SearchAlgorithm.FindNextLegDistance(
                new Route[2]{
                                new Route(Casablanca, 5),
                                new Route(Liverpool, 3) 
                            },
                0,
                Liverpool,
                BuenosAires));
        }

        /// <summary>
        /// Test Journey From Buenos Aires Via Cape Town To New York To Liverpool To Casablanca
        /// </summary>
        [TestMethod]
        public void TestJourneyFromBuenosAiresViaCapeTownToNewYorkToLiverpoolToCasablanca()
        {
             Assert.IsTrue(SearchAlgorithm.FindNextLeg(
                new Route[4]{
                                new Route(CapeTown, 4),
                                new Route(NewYork, 8),
                                new Route(Liverpool, 4),
                                new Route(Casablanca, 3)
                            },
                0,
                Casablanca,
                BuenosAires));
        }

        /// <summary>
        /// Give Excepted exception, alias exception have a code
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(Exception), "No Valid Route Found")]
        public void TestJourneyFromBuenosAiresViaCapeTownToCasablanca()
        {
            SearchAlgorithm.FindNextLeg(
                new Route[2]{
                                new Route(CapeTown, 4),
                                new Route(Casablanca, 3)
                            },
                0,
                Casablanca,
                BuenosAires);
        }

        [TestMethod]
        public void TestJourneyFromBuenosAiresToCasablancaToLiverpool()
        {
            //Assert.AreEqual(SearchAlgorithm.IsValidRoute(BuenosAires, Liverpool));
            //Assert.AreEqual(10, SearchAlgorithm.FindRoute(BuenosAires, Liverpool));
        }
    }
}
