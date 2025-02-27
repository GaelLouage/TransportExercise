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
    }
}
