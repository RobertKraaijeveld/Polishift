﻿using Dataformatter.Dataprocessing.Entities;
using Map_Displaying.Reference_Scripts;
using UnityEngine;

namespace Game_Logic.Country_Coloring
{
    public abstract class AbstractRulerHandler : MonoBehaviour
    {
        public ICountryRuler CurrentRuler; 
        protected bool IsInitialized;
        protected bool IsDone;
        protected CountryInformationReference ThisCountriesInfo;

        private void Update()
        {
            if(IsInitialized && !IsDone)
                HandleRuler();
        }

        public abstract void Init();
        public abstract string RulerToText();
        public abstract void HandleRuler();

    }
}