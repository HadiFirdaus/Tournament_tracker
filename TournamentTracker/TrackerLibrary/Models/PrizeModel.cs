namespace TrackerLibrary.Models
{
    public class PrizeModel
    {
        //unique identifier for this PrizeModel
        public int ID { get; set; }
        public int PlaceNumber { get; set; }
        public string PlaceName { get; set; }
        public decimal PlaceAmount { get; set; }
        public double PlacePercentage { get; set; }

        //1 empty constructor
        //2 overload constructor
        public PrizeModel()
        {

        }
        public PrizeModel(string PPlaceNumber, string PPlaceName, string PPlaceAmount, string PPlacePercentage)
        {
            int placeNumberValue = 0;
            int.TryParse(PPlaceNumber, out placeNumberValue);
            PlaceNumber = placeNumberValue;

            PlaceName = PPlaceName;

            decimal placeAmountValue = 0;
            decimal.TryParse(PPlaceAmount, out placeAmountValue);
            PlaceAmount = placeAmountValue;

            double placePercentageValue = 0;
            double.TryParse(PPlacePercentage, out placePercentageValue);
            PlacePercentage = placePercentageValue;
        }
    }
}
