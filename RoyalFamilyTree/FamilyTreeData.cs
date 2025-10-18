using System;

namespace RoyalFamilyTree
{
    public static class FamilyTreeData
    {
        public static FamilyMember GetWindsorFamilyTree()
        {
            // Queen Elizabeth II (1926-2022) and Prince Philip (1921-2021)
            var queenElizabeth = new FamilyMember("Queen Elizabeth II", new DateTime(1926, 4, 21), false);
            var princePhilip = new FamilyMember("Prince Philip, Duke of Edinburgh", new DateTime(1921, 6, 10), false);
            queenElizabeth.Spouse = princePhilip;
            princePhilip.Spouse = queenElizabeth;

            // Their children
            var kingCharles = new FamilyMember("King Charles III", new DateTime(1948, 11, 14), true);
            var princessAnne = new FamilyMember("Princess Anne", new DateTime(1950, 8, 15), true);
            var princeAndrew = new FamilyMember("Prince Andrew", new DateTime(1960, 2, 19), true);
            var princeEdward = new FamilyMember("Prince Edward", new DateTime(1964, 3, 10), true);

            queenElizabeth.Children.Add(kingCharles);
            queenElizabeth.Children.Add(princessAnne);
            queenElizabeth.Children.Add(princeAndrew);
            queenElizabeth.Children.Add(princeEdward);

            // King Charles III's family
            var dianaPrincessOfWales = new FamilyMember("Diana, Princess of Wales", new DateTime(1961, 7, 1), false);
            kingCharles.Spouse = dianaPrincessOfWales;
            
            var princeWilliam = new FamilyMember("Prince William", new DateTime(1982, 6, 21), true);
            var princeHarry = new FamilyMember("Prince Harry", new DateTime(1984, 9, 15), true);
            
            kingCharles.Children.Add(princeWilliam);
            kingCharles.Children.Add(princeHarry);

            // Prince William's family
            var catherinePrincessOfWales = new FamilyMember("Catherine, Princess of Wales", new DateTime(1982, 1, 9), true);
            princeWilliam.Spouse = catherinePrincessOfWales;
            
            var princeGeorge = new FamilyMember("Prince George", new DateTime(2013, 7, 22), true);
            var princessCharlotte = new FamilyMember("Princess Charlotte", new DateTime(2015, 5, 2), true);
            var princeLouie = new FamilyMember("Prince Louis", new DateTime(2018, 4, 23), true);
            
            princeWilliam.Children.Add(princeGeorge);
            princeWilliam.Children.Add(princessCharlotte);
            princeWilliam.Children.Add(princeLouie);

            // Prince Harry's family
            var meghanDuchessOfSussex = new FamilyMember("Meghan, Duchess of Sussex", new DateTime(1981, 8, 4), true);
            princeHarry.Spouse = meghanDuchessOfSussex;
            
            var archieHarrison = new FamilyMember("Prince Archie", new DateTime(2019, 5, 6), true);
            var lilibetDiana = new FamilyMember("Princess Lilibet", new DateTime(2021, 6, 4), true);
            
            princeHarry.Children.Add(archieHarrison);
            princeHarry.Children.Add(lilibetDiana);

            // Princess Anne's children
            var peterPhillips = new FamilyMember("Peter Phillips", new DateTime(1977, 11, 15), true);
            var zaraPhillips = new FamilyMember("Zara Tindall", new DateTime(1981, 5, 15), true);
            
            princessAnne.Children.Add(peterPhillips);
            princessAnne.Children.Add(zaraPhillips);

            // Prince Andrew's children
            var princessBeatrice = new FamilyMember("Princess Beatrice", new DateTime(1988, 8, 8), true);
            var princessEugenie = new FamilyMember("Princess Eugenie", new DateTime(1990, 3, 23), true);
            
            princeAndrew.Children.Add(princessBeatrice);
            princeAndrew.Children.Add(princessEugenie);

            // Prince Edward's children
            var ladyLouiseWindsor = new FamilyMember("Lady Louise Windsor", new DateTime(2003, 11, 8), true);
            var jamesViscountSevern = new FamilyMember("James, Viscount Severn", new DateTime(2007, 12, 17), true);
            
            princeEdward.Children.Add(ladyLouiseWindsor);
            princeEdward.Children.Add(jamesViscountSevern);

            return queenElizabeth;
        }
    }
}
