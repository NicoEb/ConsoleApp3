using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Morpion jeuCourant = new Morpion();

            Tour t = new Tour(0,1);
            if (t.IndexLigneJouee > 3)
            {
                Console.WriteLine("Index en dehors des limites");
            }

            jeuCourant.JouerUneCase(t);

            jeuCourant.SymboleDuJoueurQuiDoitJouer = Symbol.Croix;



            Console.WriteLine("Hello World!");
        }
    }

    public class Morpion
    {
        public Case[,] Cases;

        public Symbol SymboleDuJoueurQuiDoitJouer;

        public const int LARGEUR_PAR_DEFAUT = 3;
        public const Symbol PREMIER_SYMBOL_PAR_DEFAUT = Symbol.Croix;

        public Morpion() : this(LARGEUR_PAR_DEFAUT)
        {

        }

        public Morpion(int tailleCarre) : this(tailleCarre, PREMIER_SYMBOL_PAR_DEFAUT)
        {
           
        }

        public Morpion(int tailleCarre, Symbol premierSymbolAJouer)
        {
            Cases = new Case[tailleCarre, tailleCarre];
            for (int i = 0; i < tailleCarre; i++)
            {
                for (int j = 0; j < tailleCarre; j++)
                {
                    Case caseCourante = new Case();
                    caseCourante.SymbolCourant = null;

                    Cases[i, j] = caseCourante;
                }
            }
            SymboleDuJoueurQuiDoitJouer = premierSymbolAJouer;
        }



        public void JouerUneCase(Tour tourAJouer)
        {
            //1ère étape : récupère dans la grille de morpion la cellule qui correspond au tour à jouer
            Case laCaseJouee = this.Cases[tourAJouer.IndexLigneJouee, tourAJouer.IndexColonneJouee];

            //2ème étape : sur cette case, je lui positionne le symbole du joueur courant
            Symbol symbolAPositionnerDansCaseJouee = this.SymboleDuJoueurQuiDoitJouer;
            
            //Case.PositionnerSymbol(laCaseJouee, symbolAPositionnerDansCaseJouee);
            laCaseJouee.PositionnerSymbol(symbolAPositionnerDansCaseJouee);

            //3ème étape : j'inverse le joueur courant
            Symbol leProchainSymbolQuiDoitJouer =
                this.SymboleDuJoueurQuiDoitJouer == Symbol.Croix ? Symbol.Rond : Symbol.Croix;
            this.SymboleDuJoueurQuiDoitJouer = leProchainSymbolQuiDoitJouer;
        }

        public Symbol? DeterminerSymbolGagnant()
        {
            //Pour chaques lignes
            //  si toutes les cases de cette ligne ont le même symboles 
            //  et que ce symbole n'est pas "vide"
            //      alors le symbol gagnant est le symbol de la 1ère case de la ligne
            //      je retourne le symbole gagnant
            for (int indexLigne = 0; indexLigne < 3; indexLigne++)
            {
                if(this.Cases[indexLigne, 0].SymbolCourant != null &&
                    this.Cases[indexLigne, 0].SymbolCourant == this.Cases[indexLigne, 1].SymbolCourant
                    && this.Cases[indexLigne, 0].SymbolCourant == this.Cases[indexLigne, 2].SymbolCourant)
                {
                    return this.Cases[indexLigne, 0].SymbolCourant;
                }
            }

            //Pour chaques colonnes
            //  si toutes les cases de cette colonne ont le même symboles
            //  et que ce symbole n'est pas "vide"
            //      alors le symbole gagnant est le symbole de la 1ère case de la colonne
            //      je retourne le symbole gagnant

            for (int indexColonne = 0; indexColonne < 3; indexColonne++)
            {
                if (this.Cases[0, indexColonne].SymbolCourant != null &&
                    this.Cases[0, indexColonne].SymbolCourant == this.Cases[1, indexColonne].SymbolCourant
                    && this.Cases[0, indexColonne].SymbolCourant == this.Cases[2, indexColonne].SymbolCourant)
                {
                    return this.Cases[0, indexColonne].SymbolCourant;
                }
            }

            //Pour les 2 diagonales
            //  si toutes les cases de cette diagonale ont le même symboles
            //  et que ce symbole n'est pas "vide"
            //      alors le symbole gagnant est le symbole de la 1ère case de la diagonale
            //      je retourne le symbole gagnant

            if(this.Cases[0,0].SymbolCourant != null
                && this.Cases[0, 0].SymbolCourant == this.Cases[1, 1].SymbolCourant
                && this.Cases[0, 0].SymbolCourant == this.Cases[2, 2].SymbolCourant)
            {
                return this.Cases[0, 0].SymbolCourant;
            }


            if (this.Cases[2, 0].SymbolCourant != null
                && this.Cases[2, 0].SymbolCourant == this.Cases[1, 1].SymbolCourant
                && this.Cases[2, 0].SymbolCourant == this.Cases[0, 2].SymbolCourant)
            {
                return this.Cases[0, 0].SymbolCourant;
            }

            //Sinon
            //  Il n'y a aucun gagnant
            return null;
        }

        public void AfficherMorpion()
        {
            #region ...

            #endregion
        }
    }

    public class Case
    {
        public Symbol? SymbolCourant;

        public void PositionnerSymbol(Symbol nouveauSymbol)
        {
            this.SymbolCourant = nouveauSymbol;
        }
    }

    public enum Symbol
    {
        Croix,
        Rond,
    }

    public class Tour
    {
        public int IndexLigneJouee { get; private set; }
        public int IndexColonneJouee { get; private set; }

        public Tour(int indexLigne, int indexColonne)
        {
            IndexColonneJouee = indexColonne;
            IndexLigneJouee = indexLigne;
        }
    }

}
