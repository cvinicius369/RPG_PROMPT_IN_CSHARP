using RPG2;
using System;
using System.Data.Common;
using System.Dynamic;
using System.Reflection.Metadata.Ecma335;

public class Entity{
    private int id, hp, def, atk, doblons, xp, power;
    private string name, level;

    /* [ CONSTRUCTOR ] */
    public Entity(
        int id, string name, string level, int hp, int def, int atk, int doblons, int xp, int power
    ){ 
        this.id = id; this.name = name; this.level = level; this.hp = hp; this.def = def; 
        this.atk = atk; this.doblons = doblons; this.xp = xp; this.power = power;
    }

    /* [ GETTERS ] */
    public string getName(){ return this.name; }
    public string getLevel(){ return this.level; }
    public int getId(){ return this.id; }
    public int getHp(){ return this.hp; }
    public int getDef(){ return this.def;}
    public int getAtk(){ return this.atk; }
    public int getDoblons(){ return this.doblons;}
    public int getXp(){ return this.xp; }
    public int getPower(){ return this.power;}

    /* [ SETTERS ] */
    public void setLevel(string newLevel){ this.level = newLevel; }
    public void setHp(int newHP){ this.hp = newHP; }
    public void setDef(int def){ this.def = def; } 
    public void setAtk(int newAtk){ this.atk = newAtk; }
    public void setXP(int newXP){ this.xp = newXP; }
    public void setDoblons(int newDoblons){ this.doblons = newDoblons; }
    public void setPower(int newPower){ this.power = newPower; }    
}