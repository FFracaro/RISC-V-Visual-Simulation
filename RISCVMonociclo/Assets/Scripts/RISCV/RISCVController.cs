using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RISCVController : MonoBehaviour
{
    public ProgramCounter PC;
    public Adder Adder1;
    public Adder Adder2;
    public InstructionMemory InstMem;
    public Control ControlUnit;
    public Registers RegistersBank;
    public ImmediateGenerator ImmGen;
    public Multiplexer MuxULA;
    public ALUControl ALUControlUnit;
    public ArithmeticLogicUnit ALU;
    public AND ANDUnit;
    public Multiplexer MuxPC;
    public Memory MemUnit;
    public Multiplexer MuxResult;

    private bool instrucoes = false;

    public void ClockCycle()
    {
        if(!instrucoes)
        {
            InstructionsHolder[] test = FindObjectsOfType(typeof(InstructionsHolder)) as InstructionsHolder[];

            SetListaInstrucoes(test[0].GetInstructionsList());
        }

        instrucoes = true;
        ///////////////////////////////////

        if(PC.GetPCProximoValueDec() < GetQuantidadeInstrucoes())
        {
            RegistersBank.HideArrowsFromRegisters();

            PC.PropagarValorPC();

            // Soma do PC address com o nº 4
            Adder1.SetValorEntrada1Adder(PC.GetPCAtualValue());
            Adder1.PropagarValorAdder();

            // Não pode propagar ainda pois não possui o valor do IMM Gen
            Adder2.SetValorEntrada1Adder(PC.GetPCAtualValue());

            // Envia os valores contidos em uma instrução para as saídas da memória de instrução
            InstMem.SetNumeroInstrução(PC.GetPCAtualValue());
            InstMem.PropagarValoresInstrução();

            // Utiliza o OPCode para setar as flags na saída da unidade de controle
            ControlUnit.SetOpCodeValue(InstMem.GetOpCodeValue());
            ControlUnit.PropagarValoresControl();

            // Após receber os registradores e o regwrite, coloca na saída o conteúdo dos registradores 1 e 2
            RegistersBank.SetRegistersToUse(InstMem.GetReg1Value(), InstMem.GetReg2Value(), InstMem.GetReg3Value());
            RegistersBank.SetRegWriteValueInRegister(ControlUnit.GetRegWriteValue());
            RegistersBank.PropagarRegisterValues();

            // Recebe uma instrução e propaga o valor immediate para a ULA e valor com shiftLeft para o Adder2PC;
            ImmGen.SetInstructionToImmGen(InstMem.GetInstrucaoAtual());
            ImmGen.PropagarImmGenValue();

            // Recebe o valor do ImmGen e propaga o resultado da soma PC + ImmGen para o MuxPC
            Adder2.SetValorEntrada2BinaryAdder(ImmGen.GetImmGenValueBinaryShiftLeft());
            Adder2.PropagarValorAdder();

            // Recebe os dados do Reg2, Immediate e flag ALUSrc
            MuxULA.SetValuesEntradaMux(RegistersBank.GetContentFromRegister2(), ImmGen.GetImmGenValueToULA(), ControlUnit.GetALUSrcValue());
            MuxULA.PropagarMux();

            // A partir dos valores [30, 14:12] e do ALUOp, indicada a operação da ULA
            ALUControlUnit.SetValuesToALUControl(ControlUnit.GetALUOpValue(), InstMem.GetULAControlValue());
            ALUControlUnit.PropagarValueFromULAControl();

            // Recebe os dados dos reg1, mux (reg2 e immgen) e ULA control e realiza os cálculos
            ALU.SetULAValues(RegistersBank.GetContentFromRegister1(), MuxULA.GetSaidaMuxResult(), ALUControlUnit.GetOperacaoValueFromULAControl());
            ALU.PropagarULAValues(); 

            // Faz um and binário com os valores das flags branch e zero
            ANDUnit.SetBranchAndZeroValues(ControlUnit.GetBranchValue(), ALU.GetZeroValue());
            ANDUnit.PropagarANDValue();

            // Valores dos dois adders mais o resultado do AND do brach e zero que resulta no próximo address do PC
            MuxPC.SetValuesEntradaMux(Adder1.GetValorSaidaAdder(), Adder2.GetValorSaidaAdder(), ANDUnit.GetANDResult());
            MuxPC.PropagarMux();

            // Adiciona o novo valor calculado ao program counter
            PC.SetPCProximoValue(MuxPC.GetSaidaMuxResult());

            // Recebe um endereço da ULA e dependendo das flags Write e Read, 
            // adiciona um valor à memória ou lê um valor e coloca na saída
            MemUnit.SetMemoryValues(ALU.GetULAResult(), RegistersBank.GetContentFromRegister2(), ControlUnit.GetMemWriteValue(), ControlUnit.GetMemReadValue());
            MemUnit.PropagarMemoryValues();

            // Multiplexador responsável por decidir se o valor saído da ULA ou da Memória vai em direção ao banco de registradores
            MuxResult.SetValuesEntradaMux(ALU.GetULAResult(), MemUnit.GetMemoryValueRead(), ControlUnit.GetMemToRegValue());
            MuxResult.PropagarMux();

            // Verifica se o valor do Mux Resultado deve entrar no registrador 3, se sim adiciona
            RegistersBank.SetValueToRegister3(MuxResult.GetSaidaMuxResult());
        }

    }

    public void SetListaInstrucoes(List<string> instrucoes)
    {
        InstMem.SetInstruções(instrucoes);
    }

    public int GetQuantidadeInstrucoes()
    {
        return InstMem.GetQuantidadeInstrucoes();
    }
}
