using RPG2;
using System;
using System.Data.Common;
using System.Dynamic;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;

public class Entity{
    private int id, hp, def, atk, doblons, xp, power, vitalEnergy;
    private string name, level, ultimate, skill, typeUser;

    /* [ CONSTRUCTOR ] */
    public Entity(
        int id, string name, string level, int hp, int def, int atk,
        int doblons, int xp, int power, string skill, string ultimate,
        int vitalEnergy, string typeUser
    ){ 
        this.id = id; this.name = name; this.level = level; this.hp = hp; this.def = def; 
        this.atk = atk; this.doblons = doblons; this.xp = xp; this.power = power;
        this.skill = skill; this.ultimate = ultimate; this.vitalEnergy = vitalEnergy; 
        this.typeUser = typeUser;
    }

    /* [ GETTERS ] */
    public string getName(){ return this.name; }
    public string getLevel(){ return this.level; }
    public string getSkill(){ return this.skill;}
    public string getUltimate(){ return this.ultimate; }
    public int getId(){ return this.id; }
    public int getHp(){ return this.hp; }
    public int getDef(){ return this.def;}
    public int getAtk(){ return this.atk; }
    public int getDoblons(){ return this.doblons;}
    public int getXp(){ return this.xp; }
    public int getPower(){ return this.power;}
    public int getVitalEnergy(){ return this.vitalEnergy; }
    public string getTypeUser(){ return this.typeUser;}

    /* [ SETTERS ] */
    public void setLevel(string newLevel){ this.level = newLevel; }
    public void setHp(int newHP){ this.hp = newHP; }
    public void setDef(int def){ this.def = def; } 
    public void setAtk(int newAtk){ this.atk = newAtk; }
    public void setXP(int newXP){ this.xp = newXP; }
    public void setDoblons(int newDoblons){ this.doblons = newDoblons; }
    public void setPower(int newPower){ this.power = newPower; } 
    public void setVitalEnergy(int newVitalEnergy){ this.vitalEnergy = newVitalEnergy; }
    public void setSkill(string nskill){ this.skill = nskill; }
    public void setUltimate(string nultimate){ this.ultimate = nultimate; }
    public void setTypeUser(string ntype){ this.typeUser = ntype; }

    /* [ SKILL AND ULTIMATE ] */
    public void useSkill(){
        int consumoVital = 5;

        if(getTypeUser() == "Sangue"){
            double defAdicionada = 10 * getDef() / 100;
            double hpAdicionada = 5 * getDef() / 100;
            double atkAdicionada = 2 * getDef() / 100;
            setDef(getDef() + Convert.ToInt32(defAdicionada));
            setHp(getHp() + Convert.ToInt32(hpAdicionada));
            setAtk(getAtk() + Convert.ToInt32(atkAdicionada));
            setVitalEnergy(getVitalEnergy() - (consumoVital + 2));
        } else if (getTypeUser() == "Animal"){ 
            double atkAdicionado = 5 * getAtk() / 100;
            double defAdicionada = 5 * getDef() / 100;
            setAtk(getAtk() + Convert.ToInt32(atkAdicionado));
            setDef(getDef() + Convert.ToInt32(defAdicionada));
            setVitalEnergy(getVitalEnergy() - consumoVital);
        } else if (getTypeUser() == "Fogo"){
            double atkAdicionado = 10 * getAtk() / 100;
            setAtk(getAtk() + Convert.ToInt32(atkAdicionado));
            setVitalEnergy(getVitalEnergy() - consumoVital);
        } else if (getTypeUser() == "Alma"){
            double defAdicionada = 30 * getDef() / 100;
            double hpAdicionada = 10 * getHp() / 100;
            setDef(getDef() + Convert.ToInt32(defAdicionada));
            setHp(getHp() + Convert.ToInt32(hpAdicionada));
            setVitalEnergy(getVitalEnergy() - (consumoVital + 1));
        }
        if (consumoVital <= 0){ setHp(getHp() - 5); }
    }
}