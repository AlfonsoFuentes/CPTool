using CPTool.DTOS;
using CPTool.Entities;
using CPTool.Interfaces;

namespace CPTool.DesignPattern
{
    public interface IBuilder
    {
        void BuildPartA();


    }
    public class Builder : IBuilder
    {
        readonly IDTOManager<MWODTO, MWO> _manager;
        public Builder(IDTOManager<MWODTO, MWO> manager)
        {
            _manager = manager;
            
        }
        public MWODTO Build()
        {
            MWODTO mWODTO = new MWODTO();

            return mWODTO;

        }
    }
}