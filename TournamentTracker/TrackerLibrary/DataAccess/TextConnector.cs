using System;
using System.Collections.Generic;
using System.Linq;
using TrackerLibrary.Models;
using TrackerLibrary.DataAccess.TextHelpers;

namespace TrackerLibrary.DataAccess
{
    public class TextConnectors : IDataConnection
    {
        private const string PrizesFile = "PrizeModels.cvs";
        private const string PeopleFile = "PersonModels.cvs";
        public PersonModel CreatePerson(PersonModel model)
        {
            List<PersonModel> people = PeopleFile.FullFilePath().LoadFile().ConvertToPersonModels();
            int currentId = 1;
            if (people.Count > 0)
            {
                currentId = people.OrderByDescending(x => x.ID).First().ID + 1;
            }
            model.ID = currentId;
            people.Add(model);
            people.SaveToPeopleFile(PeopleFile);
            return model;
        }

        public PrizeModel CreatePrize(PrizeModel model)
        {
            //Load the text fie and convert the text to List<PrizeModel>
            List<PrizeModel> prizes = PrizesFile.FullFilePath().LoadFile().ConvertToPrizeModels();

            int currentId = 1;
            if(prizes.Count > 0)
            {
                currentId = prizes.OrderByDescending(x => x.ID).First().ID + 1;
            }
            model.ID = currentId;

            prizes.Add(model);


            //Load the text file
            //Convert the text to list<PrizeModel>
            //Find the max ID
            //Add the new record with the new ID (max + 1)
            //Convert the prizes to list<string>
            //Save the list<string> to the text file
            prizes.SaveToPrizeFile(PrizesFile);

            return model;
        }
    }
}
