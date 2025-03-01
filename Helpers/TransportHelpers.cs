using apiOef14._6.DTO;
using apiOef14._6.Models;

namespace apiOef14._6.Helpers
{
    public class TransportHelpers
    {
        public static void SetTransPortValues(EnqueteEntity enquete, int[,] enqueteData, int yearPos)
        {
            switch (enquete.Category)
            {
                case "E":
                    enqueteData[yearPos, 0]++;
                    break;
                case "F":
                    enqueteData[yearPos, 1]++;
                    break;
                case "OV":
                    enqueteData[yearPos, 2]++;
                    break;
                //default is A
                default:
                    enqueteData[yearPos, 3]++;
                    break;
            }
        }
        public static int[,] PopulateEnquetes(List<EnqueteEntity> enquetes, int[,] enqueteData)
        {
            foreach (var enquete in enquetes)
            {
                if (enquete.Year < 1960)
                {
                    SetTransPortValues(enquete, enqueteData, 0);
                }
                else if (enquete.Year < 1970)
                {
                    SetTransPortValues(enquete, enqueteData, 1);
                }
                else if (enquete.Year < 1980)
                {
                    SetTransPortValues(enquete, enqueteData, 2);
                }
                else if (enquete.Year < 1990)
                {
                    SetTransPortValues(enquete, enqueteData, 3);
                }
                else
                {
                    SetTransPortValues(enquete, enqueteData, 4);
                }
            }
            return enqueteData;
        }
    }
}
