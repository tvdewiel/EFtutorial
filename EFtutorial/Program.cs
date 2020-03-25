using EFtutorial.Data;
using EFtutorial.Model;
using System;

namespace EFtutorial
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //Uitgeverij u1 = new Uitgeverij("Lannoo", "Kasteelstraat 97,8700 Tielt", "info@lannoo.be");
            //Auteur a1 = new Auteur("Fieke Van der Gucht", "fieke.vandergucht@ugent");
            //Boek b1 = new Boek("Het groot Vlaams vloekboek", "Het Groot Vlaams Vloekboek behandelt twintig spitante scheldwoorden en vloeken, in twintig hilarische illustraties en een veelvoud aan weetjes. Wist je dat het brave belhamel naar een gecastreerde ram verwijst, en sletten van oorsprong 'vodden' zijn? ");
            //b1.Uitgeverij = u1;
            //b1.Auteurs.Add(a1);

            BoekManager BM = new BoekManager();
            var b = BM.ZoekBoek(7);
            //BM.VoegBoekToe(b1);
            //BM.VoegBoekToe(b1);
            ScenarioBuilder sb = new ScenarioBuilder();
            //sb.Scenario_VoegBoekToe();
            //sb.Scenario_VoegBoekToeMetMeerdereauteurs();
            //sb.Scenario_VoegBoekenToeVanzelfdeAuteur();
            //sb.Scenario_VoegUitgeverijToe();
            //sb.Scenario_VoegAuteurToe();
            //sb.Scenario_VoegAuteurToeAanBoek();
            //sb.Scenario_UpdateBoekDisconnected();
        }
    }
}