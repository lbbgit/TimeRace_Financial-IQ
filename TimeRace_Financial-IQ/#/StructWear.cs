using System.Collections;
using System.Collections.Generic;
using System;
using System.Text;
using System.Data;
//using System.Xml;
enum ItemType
{
    creature,
    equip,//equipUnBrk,
    item,//itemUnbrk,
    soul
}
interface I_justProperty
{
    string name;
    int g, f, m, s, hp, hpT, mp, mpT, look;
}
struct justProperty : I_justProperty
{ 
    ItemType itemType;
}
struct equip : I_justProperty
{
    //type

    ItemType itemType = ItemType.equip;
    string equipType;
}

struct Property
{

}

struct PropertyContainer
{
    justProperty myProperty;
    equip[] myEquips;

    //out sx
    justProperty _myPropertyShow;
    justProperty myPropertyShow{get;set;}

}