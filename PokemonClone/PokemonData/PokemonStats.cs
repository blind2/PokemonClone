namespace PokemonClone.PokemonData
{
    public  class PokemonStats
    {
        private int level;
        private string name;
        private int currentHp;
        private int hp;
        private int attack;
        private int defense;
        private int specialAttack;
        private int specialDefense;
        private  int speed;
        private Type type;

        public PokemonStats() { }
       

        public  PokemonStats(int level, string name, int bHp, int bAttack, int bDefense, int bSpecialAttack, int bSpecialDefense, int bSpeed, Type type)
        {
            this.level = level;
            this.name = name;
            hp = GetActualStats(bHp, hp);
            attack = GetActualStats(bAttack, attack);
            defense = GetActualStats(bDefense, defense);
            specialAttack = GetActualStats(bSpecialAttack, specialAttack);
            specialDefense = GetActualStats(bSpecialDefense, specialDefense);
            speed = GetActualStats(bSpeed, speed);
            currentHp = hp;
            this.type = type;

        }

        public int GetActualStats(int baseStat, int stat)
        {
            stat = baseStat + level * 2;
            return stat;
        }


        public string Name
        {
            get { return name; }
        }

        public int Level
        {
            get { return level; }
            set { level = value; }
        }

        public int Hp
        {
            get { return hp; }
            set { hp = value; }
        }

        public int Attack
        {
            get { return attack; }
        }

        public int Defense
        {
            get { return defense; }
        }

        public int Speed
        {
            get { return speed; }
        }

        public int CurrentHp
        {
            get { return currentHp; }
            set { currentHp = value; }
        }

    }
}
