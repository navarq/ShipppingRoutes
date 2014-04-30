using System;
using System.IO;

namespace ShippingRoutes
{
    public class SearchAlgorithm
    {
        public static int FindRoute(City start, City end)
        {
            int journey = 0;

            foreach (Route route in start.Connections)
            {
                if (!route.GetCity().Equals(end))
                {
                    foreach (Route nextRoute in route.GetCity().Connections)
                    {
                        if (!nextRoute.GetCity().Equals(end))
                        {
                            foreach (Route nextNextRoute in nextRoute.GetCity().Connections)
                            {
                                if (!nextNextRoute.GetCity().Equals(end))
                                {
                                    return journey;
                                }
                                else
                                    return nextNextRoute.GetDays() + nextRoute.GetDays() + route.GetDays();
                            }
                        }
                        else
                        {
                            return nextRoute.GetDays() + route.GetDays();
                        }
                    }
                }
                else
                {
                    return route.GetDays();
                }

            }
            return journey;
        }

        public static bool IsValidRoute(City startCity, City endCity)
        {
            foreach (Route route in startCity.Connections)
            {
                if (!route.GetCity().Equals(endCity))
                {
                    foreach (Route nextRoute in route.GetCity().Connections)
                    {
                        if (!nextRoute.GetCity().Equals(endCity))
                        {
                            foreach (Route nextNextRoute in nextRoute.GetCity().Connections)
                            {
                                return !nextNextRoute.GetCity().Equals(endCity) ? false : true;
                            }
                        }
                        else
                        {
                            return true;
                        }
                    }
                }
                else
                {
                    return true;
                }

            }
            return true;
        }

        public static bool FindNextLeg(Route[] returnArray, int count, City destination, City currentCity)
        {
            for (int i = 0; i < currentCity.Connections.Length; i++)
            {
                if (CanContinueSearch(returnArray, currentCity.Connections[i].GetCity()))
                {
                    if (count == returnArray.Length)
                    {
                        throw new Exception("No Valid Route Found");
                    }
                    returnArray[count] = currentCity.Connections[i];
                    if(currentCity.Connections[i].GetCity().Equals(destination))
                    {
                        return true;
                    }
                    else
                    {
                        if(FindNextLeg(returnArray, count + 1, destination, currentCity.Connections[i].GetCity())) 
                        {
                            return true;
                        }
                    }
                }
            } 
            return true;
        }

        public static int FindNextLegDistance(Route[] returnArray, int count, City destination, City currentCity)
        {
            for (int i = 0; i < currentCity.Connections.Length; i++)
            {
                if (CanContinueSearch(returnArray, currentCity.Connections[i].GetCity()))
                {
                    if (currentCity.Connections[i].GetCity().Equals(destination))
                    {
                        return returnArray[count].GetDays();
                    }
                    else
                    {
                        if (FindNextLeg(returnArray, count + 1, destination, returnArray[i].GetCity()))
                        {
                            return returnArray[count].GetDays() + FindNextLegDistance(returnArray, count + 1, destination, currentCity.Connections[i].GetCity());
                        }
                    }
                }
            }
            return 0;
        }


        private static bool CanContinueSearch(Route[] returnArray, City city)
        {
            for (int i = 0; i < returnArray.Length; i++)
            {
                if (returnArray[i].GetCity().Equals(city.GetCityName()))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
