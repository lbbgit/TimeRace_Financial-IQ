using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimeRace_Financial_IQ._
{
    interface I_WearAble
    {

    }

    //people : equip : item 
    // skill + look + [weak]
    //sum:temp,look
    //equip[8+m:n][jjjztg]
    //[soul]:key [soul spell:pos+FF+ |/_s ] ::gm_close_withNofight;;
    interface I_Property
    {
        public int attack, defense;
    }

    interface I_PropertyContainer
    {
        public I_Property myProp;
        public I_Property[] myEquip;

        public I_Property Prop{get;set;}
        //public int attack, defense;
    }
}


