using RPG2;
using System;
using System.Data.Common;
using System.Dynamic;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;

public class Entity{
    private int id, hp, def, atk, doblons, xp, power, vitalEnergy, progress;
    private string name, level, ultimate, skill, typeUser;

    /* [ CONSTRUCTOR ] */
    public Entity(
        int id, string name, string level, int hp, int def, int atk,
        int doblons, int xp, int power, string skill, string ultimate,
        int vitalEnergy, string typeUser, int progress
    ){ 
        this.id = id; this.name = name; this.level = level; this.hp = hp; this.def = def; 
        this.atk = atk; this.doblons = doblons; this.xp = xp; this.power = power;
        this.skill = skill; this.ultimate = ultimate; this.vitalEnergy = vitalEnergy; 
        this.typeUser = typeUser; this.progress = progress;
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
    public int getProgress(){ return this.progress; }
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
    public void setProgress(int newProgress){ this.progress = newProgress; }

    /* [ SKILL AND ULTIMATE ] */
    public void useSkill(){
        switch(getTypeUser()){
            case "Sangue": aplicaBonus(5,2,10); consumoVital(7); break;
            case "Animal": aplicaBonus(0,5,5); consumoVital(5); break;
            case "Fogo": aplicaBonus(0,10,0); consumoVital(5); break;
            case "Alma": aplicaBonus(10,0,30); consumoVital(6); break;
            case "Forca": aplicaBonus(0,10,0); consumoVital(5); break;
            case "Controle": aplicaBonus(5,0,30); consumoVital(6); break;
            case "Comum": aplicaBonus(0,0,0); consumoVital(0); break;
            default: break;   
        }
    }
    public void useUltimate(){
        switch(getTypeUser()){
            case "Sangue": aplicaBonus(-5,75,45); consumoVital(75); break;
            case "Animal": aplicaBonus(-2,50,50); consumoVital(60); break;
            case "Fogo": aplicaBonus(-1,75,10); consumoVital(45); break;
            case "Alma": aplicaBonus(-10,30,50); consumoVital(60); break;
            case "Forca": aplicaBonus(0,80,10); consumoVital(70); break;
            case "Controle": aplicaBonus(10,30,90); consumoVital(75); break;
            case "Comum": aplicaBonus(25,25,25); consumoVital(75); break;
            default: break;   
        }
    }
    public void aplicaBonus(int bhp, int batk, int bdef){
        int defAdicionada = Convert.ToInt32(bdef * getDef() / 100);
        int hpAdicionada = Convert.ToInt32(bhp * getHp() / 100);
        int atkAdicionada = Convert.ToInt32(batk * getAtk() / 100);
        setHp(getHp() + hpAdicionada);
        setDef(getDef() + defAdicionada);
        setAtk(getAtk() + atkAdicionada);
    }
    public void consumoVital(int consumo){
        setVitalEnergy(getVitalEnergy() - consumo);
        if (getVitalEnergy() <= 0){ setHp(getHp() - 5); }
    }
}