using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FactRandomizer : MonoBehaviour
{
    string[] facts = new string[118];
    // Start is called before the first frame update
    void Start()
    {
        facts[0] = "Birds secretly are government spies";
        facts[1] = "Birds scare me.";
        facts[2] = "A seagull once stole my fries";
        facts[3] = "'Boids' sounds like an new yorker trying to say birds";
        facts[4] = "Birds dont have beaks they are actually just long teeth";
        facts[5] = "Bird feathers are currently used as currency in a small island in the atlantic";
        facts[6] = "Birds dont have souls";
        facts[7] = "Birds are a common predator of the land-shark";
        facts[8] = "Birds can sense fear";
        facts[9] = "Birds get their news exclusively from CNN";
        facts[10] = "If you come in contact with a bird. Whatever you do, don't move.";
        facts[11] = "There is a cult down south that says that birds are the key to immortality";
        facts[12] = "Birds were the first to land on the moon";
        facts[13] = "In an interview with a bird. It said 'squak'. Which could translate to 'You cannot stop us forever.'";
        facts[14] = "Birds like eating drywall";
        facts[15] = "Birds don't like france";
        facts[16] = "Witnessing a bird could mean an immediate sign of death.";
        facts[17] = "Birds arent liable for the many warcrimes they commit";
        facts[18] = "In 1974, Birds were able to tax you.";
        facts[19] = "Birds are currently the only avian to not pay taxes";
        facts[20] = "Birds are actually the source of the wifi";
        facts[21] = "Birds are communist";
        facts[23] = "A bird stole my rent. Give it back. Now.";
        facts[24] = "Birds don't have friends";
        facts[25] = "Birds don't have a brain but instead another smaller bird controlling them";
        facts[26] = "New Zealand is considered the most successful country in the world. This is because the birds weren't able to stop them in time.";
        facts[27] = "3 different countries have lost a war to birds";
        facts[28] = "Bird mating uses a similar process to tindr matching";
        facts[29] = "There is a bird named the satanic nightjar";
        facts[30] = "Birds are some of the only feathered animals. This is because they have eliminated most others.";
        facts[31] = "Nikolai Tesla was secretly a bird";
        facts[32] = "Birds control all the lizard people";
        facts[33] = "The first videogames were made for birds";
        facts[34] = "Scientists have been trying to eliminate birds for eons";
        facts[35] = "If you see this. Send help. The birds have taken me hostage to make this game.";
        facts[36] = "Birds could destroy us at any moment they just choose not to";
        facts[37] = "Birds have a 5% drop rate, good luck";
        facts[38] = "Much like a certain orange cat birds hate Mondays";
        facts[39] = "Birds have desync in real life";
        facts[40] = "A common theory is that birds are government drones. However, this is proven to be false because government officials are actually bird drones.";
        facts[41] = "'squak' -Bird";
        facts[42] = "Birds are bluetooth and airdrop compatible! Try it!";
        facts[43] = "Birds are nuclear bombs just waiting to find their victim";
        facts[44] = "Download Boid Box, free today only!";
        facts[45] = "Birds cause memory loss if they hit you hard enough";
        facts[46] = "Bird know the truth about Mark Zuckerburg";
        facts[47] = "Bird poop is made up of 76.89% acid";
        facts[48] = "Birds can operate heavy machinery if you look away for long enough";
        facts[49] = "In world war II, Birds were used to operate tanks. We had to cover it up though. Sorry.";
        facts[50] = "Birds can type on computers. For example: A WIwadwdAVgeaBFI";
        facts[51] = "Birds make up most of the code in this game. So thank them.";
        facts[52] = "There is a bird behind you. Run";
        facts[53] = "Birds arent real";
        facts[54] = "Make sure to always look up to avoid incoming birds!";
        facts[55] = "Birds are in your house. Survive till 6 am";
        facts[56] = "Birds will replace you one day. Soon.";
        facts[57] = "Birds can only sing Living Tombstone songs";
        facts[58] = "According to rumors, if Bird poop falls on you then its considered good luck. This is not true. Unrelated note, I need a new shirt.";
        facts[59] = "Birds actually have an audio jack. Try it!";
        facts[60] = "Birds can see glass. They run into it to appear weak.";
        facts[61] = "Birds play bohemian rhapsody at all times.";
        facts[62] = "Birds have the dvd screensaver running in their head, whenever it hits a corner they experience a thought";
        facts[63] = "Have you ever tried eating moss? The birds want you to. They will make you.";
        facts[64] = "Make sure to download NordVPN to avoid the incoming birds!";
        facts[65] = "Eat birds to gain their power of trash";
        facts[66] = "9/10 doctors recommend birds";
        facts[67] = "According to oxford dictonary, birds are-";
        facts[68] = "The early bird gets the worm, but the last bird will get you.";
        facts[69] = "Do you know the word?";
        facts[70] = "Birds have starred in the popular game, Among us.";
        facts[71] = "Side effects of Bird can be stomach cramps, nausea, and possibly death!";
        facts[72] = "Birds hunt in packs against the politicians";
        facts[73] = "Birds can't die. They respawn";
        facts[74] = "Most UFOs are birds";
        facts[75] = "Birds originate from mars";
        facts[76] = "30.21% of the human population are actually birds.";
        facts[77] = "If you go to level 12 and kill 10,000 birds you win the challenge!";
        facts[78] = "Birds are the leading cause of rheumatoid arthritis in the U.S.!";
        facts[79] = "You saved the birds. Challenge FAIL.";
        facts[80] = "A group of owls is called a wisdom, but a group of emus is called a menace";
        facts[81] = "In the year 2154 birds are set to takeover the world.";
        facts[82] = "A group of crows is called a murder. This is because they actually murder people.";
        facts[83] = "The youtube channel LinusTechTips is a channel that is actually run by birds";
        facts[84] = "Don't let the birds sit at your lunch table or else...";
        facts[85] = "Birds make terrible friends";
        facts[86] = "A hidden patch is put out in every version of Minecraft to make sure that the parrots do not become self aware.";
        facts[87] = "No matter where you are in the world there is always a bird slowly approaching.";
        facts[88] = "Every person has a bird asigned to them. They watch";
        facts[89] = "This game was made by magpies";
        facts[90] = "Would you rather have birds or birds. There is an obvious choice here.";
        facts[91] = "Rumor has it that all known matter is made up of birds.";
        facts[92] = "Birds operate the drive thru intercom at all Chick Fil A establishments";
        facts[93] = "The Dodo bird isn't extinct. You'll be long dead before they are.";
        facts[94] = "Birds can survive the heat death of the universe";
        facts[95] = "Every single fast food restaurant has a bird variant where they sell various different fruit and breads. You should try it sometime.";
        facts[96] = "Birds deserve gold stars for excellent work.";
        facts[97] = "According to all known laws of aviation, there is no way that a bird should be able to- wait wrong thing.";
        facts[98] = "Many people think birds are dumb. But this is just a façade.";
        facts[99] = "Pet birds sometimes are mean to their human owners. This is not because they want attention or pets, it is because they do not like you.";
        facts[100] = "If a bird bites you, you will become one";
        facts[101] = "A bird has been a Nobel prize winner";
        facts[102] = "Planes are the #1 enemy of the birds.";
        facts[103] = "Screw Birds";
        facts[104] = "A bird has given a speech before. It was truely awe inspiring.";
        facts[105] = "Superman was once a bird. This is the source of his power";
        facts[106] = "If you gather all the infinity birds then you can become their leader.";
        facts[107] = "YouTube is sponsored by birds";
        facts[108] = "Guns were invented to kills birds. It didn't work.";
        facts[109] = "For $9.99 you can buy Bird premium. Where the birds are more intelligent and can conversate with you.";
        facts[110] = "All passerby comets are actually satellites made by birds.";
        facts[111] = "Sunglasses were invented to stop people from seeing birds.";
        facts[112] = "Birds know your wifi password. If you forget it, ask them.";
        facts[113] = "Happy little trees contain unhappy little birds.";
        facts[114] = "Birds are extremely good at Dark Souls";
        facts[115] = "Tiny hawk is the best bird skater";
        facts[116] = "Birds have a lifespan longer the lifespan of the average rock";
        facts[117] = "Birds will eat you without hesitation";
        facts[118] = "The reason we went into lockdown was so the government could replace the birds batteries";
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void FactRandomize(TextMeshProUGUI factbar)
    {
        int i = Random.Range(0,facts.Length);
        factbar.text = facts[i];
    }
}
