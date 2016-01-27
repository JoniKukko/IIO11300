/*
* Copyright (C) JAMK/IT/H3247 Joni Kukko
* This file is part of the IIO11300 course project.
* Created: 27.01.2016
* Authors: Joni Kukko
*/
using System;
using System.Collections.Generic;

namespace Tehtava2
{
    class Lotto
    {
        // oletus min ja max avulla heitetään exceptionia tarvittaessa
        private int 
            _minValue = -1,
            _maxValue = -1;

        // vain yksittäistä randomia käytetään
        private readonly Random _random = new Random(Guid.NewGuid().GetHashCode());
        

        // Asetetaan min ja max arvot numeroille
        public void setRange(int minValue, int maxValue)
        {
            // tarkistukset, min ja max ei voi olla alle nollan eikä max voi olla alle min
            if (minValue < 0)
                throw new ArgumentException("Parameter cannot be under zero.", "minValue");
            if (maxValue < 0)
                throw new ArgumentException("Parameter cannot be under zero.", "maxValue");
            if (maxValue < minValue)
                throw new ArgumentException("Parameter cannot be under minValue.", "maxValue");

            // asetetaan arvot
            this._minValue = minValue;
            this._maxValue = maxValue;
        }
        

        // luodaan randomit numerot
        public List<int> getNumbers(int count)
        {
            // tarkastetaan että jotain arvoja on annettu
            if (this._minValue == -1)
                throw new Exception("Minimum range not set.");
            if (this._maxValue == -1)
                throw new Exception("Maximum range not set.");
            if (count <= 0)
                throw new ArgumentException("Parameter cannot be under or equal to zero.", "count");

            // luodaan uusi lista ja täytetään se satunnaisilla luvuilla siten
            // ettei kahta samaa lukua ole
            List<int> numbers = new List<int>();
            do
            {
                int newNumber = _random.Next(this._minValue, this._maxValue + 1);
                
                // tarkastetaan ettei sitä numeroa vielä listalla ole
                if (!numbers.Contains(newNumber))
                    numbers.Add(newNumber);

            } while (numbers.Count < count);

            // järjestetään pienimmästä suurimpaan
            numbers.Sort();
            return numbers;
        }


        // ylikuormitus ettei setRangea tarvitse välttämättä
        // erikseen käyttää
        public List<int> getNumbers(int minValue, int maxValue, int count)
        {
            this.setRange(minValue, maxValue);
            return this.getNumbers(count);
        }

    }
}
