using System;
namespace td8
{
    public class clients
    {
        public string name;
        public bool blocked;
        public float value;
        public clients(string _name, float _value, bool _blocked){
            this.name = _name;
            this.value = _value;
            this.blocked = _blocked;
        }
        public string tostring(){
            return this.name+";"+Convert.ToString(this.value)+";"+Convert.ToString(blocked);
        }
    }
}