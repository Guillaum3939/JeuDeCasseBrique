using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Audio.OpenAL;
using OpenTK.Audio;

namespace JeuDeCasseBrique
{
    class GestionAudio
    {
         #region Attribut
        //musique ambiance
        AudioContext audioContext;
        int bufferMusique;
        int sourceMusique;
        FichierWAV fichierMusiquePricipale;
        float volumeMusique;
        bool effetActif ;


        // son ouch
        int bufferOuch;
        int sourceOuch;
        FichierWAV fichierOuch;

        //son pew pew pew
        int bufferPewPew;
        int sourcePewPew;
        FichierWAV fichierPewPew;

        //son salsa
        int bufferSalsa;
        int sourceSalsa;
        FichierWAV fichierSalsa;
 

        //son splash
        int bufferSplash;
        int sourceSplash;
        FichierWAV fichierSplash;

        //son defaite
        int bufferDefaite;
        int sourceDefaite;
        FichierWAV fichierDefaite;

        //son GameOver
        int bufferGameOver;
        int sourceGameOver;
        FichierWAV fichierGameOver;

        //son pleure
        int bufferPleure;
        int sourcePleure;
        FichierWAV fichierPleure;

        //son the wineris
        int bufferWinner;
        int sourceWinner;
        FichierWAV fichierWinner;

        //son destruction
        int bufferDestruct;
        int sourceDestruct;
        FichierWAV fichierDestruct;

        // son applause
        int bufferApplause;
        int sourceApplause;
        FichierWAV fichierApplause;

        #endregion // Attribut

        #region Constructeur
        public GestionAudio()
        {
            audioContext = new AudioContext();
            fichierMusiquePricipale = new FichierWAV("./audio/musicAmbiance.wav");
            fichierOuch = new FichierWAV("./audio/Ouch.wav");
            fichierPewPew = new FichierWAV("./audio/PewPew.wav");
            fichierSalsa = new FichierWAV("./audio/Salsa.wav");
            fichierSplash = new FichierWAV("./audio/Splash.wav");
            fichierDefaite = new FichierWAV("./audio/FailWahWah.wav");
            fichierGameOver = new FichierWAV("./audio/GameOver.wav");
            fichierPleure = new FichierWAV("./audio/Pleures.wav");
            fichierApplause = new FichierWAV("./audio/Applause.wav");
            fichierDestruct = new FichierWAV("./audio/DestructionCaisse.wav");
            fichierWinner = new FichierWAV("./audio/AndTheWinnerIs.wav");

            init();
        }

        private void init()
        {
            // musique d'ambiance
            volumeMusique = 1.0f;
            bufferMusique = AL.GenBuffer();
            sourceMusique = AL.GenSource();
            AL.BufferData(bufferMusique, fichierMusiquePricipale.GetFormatSonAL(), 
                fichierMusiquePricipale.getDonneesSonores(),
                fichierMusiquePricipale.getQteDonneesSonores(), 
                fichierMusiquePricipale.getFrequence());
            AL.Source(sourceMusique, ALSourcei.Buffer, bufferMusique);
            AL.Source(sourceMusique, ALSourceb.Looping, true);
            AL.Listener(ALListenerf.Gain, volumeMusique);

            //Son ouch
            bufferOuch = AL.GenBuffer();
            sourceOuch = AL.GenSource();
            AL.BufferData(bufferOuch, fichierOuch.GetFormatSonAL(),
                fichierOuch.getDonneesSonores(),
                fichierOuch.getQteDonneesSonores(),
                fichierOuch.getFrequence());
            AL.Source(sourceOuch, ALSourcei.Buffer, bufferOuch);
            AL.Source(sourceOuch, ALSourceb.Looping, false);
            AL.Listener(ALListenerf.Gain, volumeMusique);

            //Son Pew Pew
            bufferPewPew = AL.GenBuffer();
            sourcePewPew = AL.GenSource();
            AL.BufferData(bufferPewPew, fichierPewPew.GetFormatSonAL(),
                fichierPewPew.getDonneesSonores(),
                fichierPewPew.getQteDonneesSonores(),
                fichierPewPew.getFrequence());
            AL.Source(sourcePewPew, ALSourcei.Buffer, bufferPewPew);
            AL.Source(sourcePewPew, ALSourceb.Looping, false);
            AL.Listener(ALListenerf.Gain, volumeMusique);

            //Son salsa
            bufferSalsa = AL.GenBuffer();
            sourceSalsa = AL.GenSource();
            AL.BufferData(bufferSalsa, fichierSalsa.GetFormatSonAL(),
                fichierSalsa.getDonneesSonores(),
                fichierSalsa.getQteDonneesSonores(),
                fichierSalsa.getFrequence());
            AL.Source(sourceSalsa, ALSourcei.Buffer, bufferSalsa);
            AL.Source(sourceSalsa, ALSourceb.Looping, false);
            AL.Listener(ALListenerf.Gain, volumeMusique);

            //Son splash
            bufferSplash = AL.GenBuffer();
            sourceSplash = AL.GenSource();
            AL.BufferData(bufferSplash, fichierSplash.GetFormatSonAL(),
                fichierSplash.getDonneesSonores(),
                fichierSplash.getQteDonneesSonores(),
                fichierSplash.getFrequence());
            AL.Source(sourceSplash, ALSourcei.Buffer, bufferSplash);
            AL.Source(sourceSplash, ALSourceb.Looping, false);
            AL.Listener(ALListenerf.Gain, volumeMusique);

            //Son defaite
            bufferDefaite = AL.GenBuffer();
            sourceDefaite = AL.GenSource();
            AL.BufferData(bufferDefaite, fichierDefaite.GetFormatSonAL(),
                fichierDefaite.getDonneesSonores(),
                fichierDefaite.getQteDonneesSonores(),
                fichierDefaite.getFrequence());
            AL.Source(sourceDefaite, ALSourcei.Buffer, bufferDefaite);
            AL.Source(sourceDefaite, ALSourceb.Looping, false);
            AL.Listener(ALListenerf.Gain, volumeMusique);

            //Son GameOver
            bufferGameOver = AL.GenBuffer();
            sourceGameOver = AL.GenSource();
            AL.BufferData(bufferGameOver, fichierGameOver.GetFormatSonAL(),
                fichierGameOver.getDonneesSonores(),
                fichierGameOver.getQteDonneesSonores(),
                fichierGameOver.getFrequence());
            AL.Source(sourceGameOver, ALSourcei.Buffer, bufferGameOver);
            AL.Source(sourceGameOver, ALSourceb.Looping, false);
            AL.Listener(ALListenerf.Gain, volumeMusique);

            //Son Pleure
            bufferPleure = AL.GenBuffer();
            sourcePleure = AL.GenSource();
            AL.BufferData(bufferPleure, fichierPleure.GetFormatSonAL(),
                fichierPleure.getDonneesSonores(),
                fichierPleure.getQteDonneesSonores(),
                fichierPleure.getFrequence());
            AL.Source(sourcePleure, ALSourcei.Buffer, bufferPleure);
            AL.Source(sourcePleure, ALSourceb.Looping, false);
            AL.Listener(ALListenerf.Gain, volumeMusique);

            //Son Applause
            bufferApplause = AL.GenBuffer();
            sourceApplause = AL.GenSource();
            AL.BufferData(bufferApplause, fichierApplause.GetFormatSonAL(),
                fichierApplause.getDonneesSonores(),
                fichierApplause.getQteDonneesSonores(),
                fichierApplause.getFrequence());
            AL.Source(sourceApplause, ALSourcei.Buffer, bufferApplause);
            AL.Source(sourceApplause, ALSourceb.Looping, false);
            AL.Listener(ALListenerf.Gain, volumeMusique);

            //Son Destruct
            bufferDestruct = AL.GenBuffer();
            sourceDestruct = AL.GenSource();
            AL.BufferData(bufferDestruct, fichierDestruct.GetFormatSonAL(),
                fichierDestruct.getDonneesSonores(),
                fichierDestruct.getQteDonneesSonores(),
                fichierDestruct.getFrequence());
            AL.Source(sourceDestruct, ALSourcei.Buffer, bufferDestruct);
            AL.Source(sourceDestruct, ALSourceb.Looping, false);
            AL.Listener(ALListenerf.Gain, volumeMusique);

            //Son Winner
            bufferWinner = AL.GenBuffer();
            sourceWinner = AL.GenSource();
            AL.BufferData(bufferWinner, fichierWinner.GetFormatSonAL(),
                fichierWinner.getDonneesSonores(),
                fichierWinner.getQteDonneesSonores(),
                fichierWinner.getFrequence());
            AL.Source(sourceWinner, ALSourcei.Buffer, bufferWinner);
            AL.Source(sourceWinner, ALSourceb.Looping, false);
            AL.Listener(ALListenerf.Gain, volumeMusique);

        }
        #endregion //Constructeur

        #region methode
        ~GestionAudio()
        {
            // musique ambiance
            AL.SourceStop(sourceMusique);
            AL.DeleteSource(sourceMusique);
            AL.DeleteBuffer(bufferMusique);

            //Son ouch
            AL.SourceStop(sourceOuch);
            AL.DeleteSource(sourceOuch);
            AL.DeleteBuffer(bufferOuch);

            //Son PewPew
            AL.SourceStop(sourcePewPew);
            AL.DeleteSource(sourcePewPew);
            AL.DeleteBuffer(bufferPewPew);

            //Son salsa
            AL.SourceStop(sourceSalsa);
            AL.DeleteSource(sourceSalsa);
            AL.DeleteBuffer(bufferSalsa);

            //Son Splash
            AL.SourceStop(sourceSplash);
            AL.DeleteSource(sourceSplash);
            AL.DeleteBuffer(bufferSplash);

            //Son GameOver
            AL.SourceStop(sourceGameOver);
            AL.DeleteSource(sourceGameOver);
            AL.DeleteBuffer(bufferGameOver);

            //Son Pleure
            AL.SourceStop(sourcePleure);
            AL.DeleteSource(sourcePleure);
            AL.DeleteBuffer(bufferPleure);

            //Son Applause
            AL.SourceStop(sourceApplause);
            AL.DeleteSource(sourceApplause);
            AL.DeleteBuffer(bufferApplause);

            //Son Destruct
            AL.SourceStop(sourceDestruct);
            AL.DeleteSource(sourceDestruct);
            AL.DeleteBuffer(bufferDestruct);

            //Son Winner
            AL.SourceStop(sourceWinner);
            AL.DeleteSource(sourceWinner);
            AL.DeleteBuffer(bufferWinner);

        }

        public void demarrerMusiqueDeFond()
        {
            AL.SourcePlay(sourceMusique);
        }

        public void jouerSonOuch()
        {
            AL.SourcePlay(sourceOuch);
        }

        public void jouerSonPewPew()
        {
            effetActif = true;
            AL.SourcePlay(sourcePewPew);
            effetActif = false;
        }

        public void jouerSonSalsa()
        {
            effetActif = true;
            AL.SourcePlay(sourceSalsa);
            effetActif = false;
        }

        public void jouerSonSplash()
        {
            effetActif = true;
            AL.SourcePlay(sourceSplash);
            effetActif = false;

        }

        public void jouerSonDefaite()
        {
            AL.SourcePlay(sourceDefaite);

            // Attendre la fin du Wah Wah avant de poursuivre, et diminuer le volume

            float volumeMusique;
            AL.GetSource((uint)sourceMusique, ALSourcef.Gain, out volumeMusique);
            ALSourceState etatDefaite;
            do
            {
                if (volumeMusique > 0.0f)
                {
                    volumeMusique -= 0.000001f;
                    //Ajuster le volume avec la nouvelle valeur
                    AL.Source(sourceMusique, ALSourcef.Gain, volumeMusique);
                }
                etatDefaite = AL.GetSourceState(sourceDefaite);
            } while (etatDefaite == ALSourceState.Playing);

            AL.DeleteSource(sourceDefaite);
            AL.DeleteBuffer(bufferDefaite);
        }

        public void jouerSonGameOver()
        {
            AL.SourcePlay(sourceGameOver);
        }

        public void jouerSonPleure()
        {
            effetActif = true;
            AL.SourcePlay(sourcePleure);
            effetActif = false;


        }

        public void jouerWinner()
        {
            AL.SourcePlay(sourceWinner);
        }

        public void jouerDestruct()
        {
            AL.SourcePlay(sourceDestruct);
        }

        public void jouerApplause()
        {
            AL.SourcePlay(sourceApplause);

            // Attendre la fin du Wah Wah avant de poursuivre, et diminuer le volume

            float volumeMusique;
            AL.GetSource((uint)sourceMusique, ALSourcef.Gain, out volumeMusique);
            ALSourceState etatApplause;
            do
            {
                if (volumeMusique > 0.0f)
                {
                    volumeMusique -= 0.000001f;
                    //Ajuster le volume avec la nouvelle valeur
                    AL.Source(sourceMusique, ALSourcef.Gain, volumeMusique);
                }
                etatApplause = AL.GetSourceState(sourceApplause);
            } while (etatApplause == ALSourceState.Playing);

            AL.DeleteSource(sourceApplause);
            AL.DeleteBuffer(bufferApplause);
        }

        public bool effetSonoreEntrainDeJouer()
        {
            return effetActif;
        }

        public void setVolumeMusique(int nouveauVolume)
        {

            AL.Listener(ALListenerf.Gain, (float)nouveauVolume/100);
           
        }
        #endregion //methode
        
    }
}
