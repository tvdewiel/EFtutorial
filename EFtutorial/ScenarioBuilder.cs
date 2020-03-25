using System;
using System.Collections.Generic;
using System.Text;
using EFtutorial.Model;

namespace EFtutorial
{
    public class ScenarioBuilder
    {
        public void Scenario_VoegBoekToe()
        {
            Uitgeverij u1 = new Uitgeverij("Lannoo", "Kasteelstraat 97,8700 Tielt", "info@lannoo.be");
            Auteur a1 = new Auteur("Fieke Van der Gucht", "fieke.vandergucht@ugent");
            Boek b1 = new Boek("Het groot Vlaams vloekboek", "Het Groot Vlaams Vloekboek behandelt twintig spitante scheldwoorden en vloeken, in twintig hilarische illustraties en een veelvoud aan weetjes. Wist je dat het brave belhamel naar een gecastreerde ram verwijst, en sletten van oorsprong 'vodden' zijn? ");
            b1.Uitgeverij = u1;
            b1.Auteurs.Add(a1);

            BoekManager BM = new BoekManager();
            BM.VoegBoekToe(b1);            
        }
        public void Scenario_VoegBoekToeMetMeerdereauteurs()
        {
            Uitgeverij u1 = new Uitgeverij("Lannoo", "Kasteelstraat 97,8700 Tielt", "info@lannoo.be");
            Auteur a1 = new Auteur("Fieke Van der Gucht", "fieke.vandergucht@ugent");
            Auteur a2 = new Auteur("Marten van der Meulen", "Marten.van.der.Meulen@iets.com");
            Boek b1 = new Boek("Het groot Vlaams vloekboek", "Het Groot Vlaams Vloekboek behandelt twintig spitante scheldwoorden en vloeken, in twintig hilarische illustraties en een veelvoud aan weetjes. Wist je dat het brave belhamel naar een gecastreerde ram verwijst, en sletten van oorsprong 'vodden' zijn? ");
            b1.Uitgeverij = u1;
            b1.Auteurs.Add(a1);
            b1.Auteurs.Add(a2);

            BoekManager BM = new BoekManager();
            BM.VoegBoekToe(b1);
        }
        public void Scenario_VoegBoekenToeVanzelfdeAuteur()
        {
            Uitgeverij u1 = new Uitgeverij("Lannoo", "Kasteelstraat 97,8700 Tielt", "info@lannoo.be");
            Auteur a1 = new Auteur("Fieke Van der Gucht", "fieke.vandergucht@ugent");
            Boek b1 = new Boek("Het groot Vlaams vloekboek", "Het Groot Vlaams Vloekboek behandelt twintig spitante scheldwoorden en vloeken, in twintig hilarische illustraties en een veelvoud aan weetjes. Wist je dat het brave belhamel naar een gecastreerde ram verwijst, en sletten van oorsprong 'vodden' zijn? ");
            b1.Uitgeverij = u1;
            b1.Auteurs.Add(a1);
            Boek b2 = new Boek("Atlas van de Nederlandse taal - Editie Vlaanderen", "Taal boeit heel veel mensen. Kijk maar naar het succes van de jaarlijkse zoektocht naar het 'woord van het jaar'. Maar boeken over taal zijn vaak technisch, richten zich op één specifiek aspect en zijn meestal nogal saai. Daar wil deze Atlas van de Nederlandse taal resoluut korte metten mee maken.");
            b2.Uitgeverij = u1;
            b2.Auteurs.Add(a1);

            BoekManager BM = new BoekManager();
            BM.VoegBoekToe(b1);
            BM.VoegBoekToe(b2);
        }
        public void Scenario_VoegUitgeverijToe()
        {
            Uitgeverij u = new Uitgeverij("Apress", "Tiergartenstraße 15-17,69121 Heidelberg,Germany", "customerservice@springernature.com");
            BoekManager BM = new BoekManager();
            BM.VoegUitgeverijToe(u);
        }
        public void Scenario_VoegAuteurToe()
        {
            Auteur a=new Auteur("Marten van der Meulen", "Marten.van.der.Meulen@iets.com");
            BoekManager BM = new BoekManager();
            BM.VoegAuteurToe(a);
        }
        public void Scenario_VoegAuteurToeAanBoek()
        {
            Auteur a = new Auteur("Marten van der Meulen", "Marten.van.der.Meulen@iets.com");
            BoekManager BM = new BoekManager();
            Boek b=BM.ZoekBoek(7); //boekID
            b.Auteurs.Add(a);
            BM.UpdateDB();
        }
        public void Scenario_UpdateBoekDisconnected()
        {
            Auteur a = new Auteur("Marten van der Meulen", "Marten.van.der.Meulen@iets.com");
            BoekManager BM = new BoekManager();
            Boek b = new Boek("VloekBoek","om te vloeken zekers");
            b.Id = 8;//boekID
            b.Auteurs.Add(a);
            BM.UpdateBoek(b);
        }
    }
}
