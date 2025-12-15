<?xml version="1.0" encoding="UTF-8"?>
<turingmachine>
	<meta>
		<author />
		<title />
		<description />
		<created>12. 5. 2008 15:24:53</created>
		<modified>12. 5. 2008 15:24:53</modified>
	</meta>
	<machine type="TM">
		<tapes>
			<tape id="0">
				<head id="0" position="-10" />
				<cell position="-10">1</cell>
				<cell position="-9">1</cell>
				<cell position="-8">1</cell>
				<cell position="-7">1</cell>
				<cell position="-6">1</cell>
				<cell position="-5">$</cell>
				<cell position="-4">1</cell>
				<cell position="-3">1</cell>
				<cell position="-2">1</cell>
				<cell position="-1">€</cell>
			</tape>
		</tapes>
		<states>
			<state id="q0">
				<name>q0</name>
				<comment />
				<x>96</x>
				<y>167</y>
				<initial />
			</state>
			<state id="q1">
				<name>q1</name>
				<comment />
				<x>438</x>
				<y>74</y>
			</state>
			<state id="q2">
				<name>q2</name>
				<comment />
				<x>300</x>
				<y>255</y>
			</state>
			<state id="qv">
				<name>qv</name>
				<comment />
				<x>649</x>
				<y>129</y>
			</state>
			<state id="qf">
				<name>qf</name>
				<comment />
				<x>902</x>
				<y>65</y>
				<final />
			</state>
			<state id="q3">
				<name>q3</name>
				<comment />
				<x>669</x>
				<y>228</y>
			</state>
			<state id="q4">
				<name>q4</name>
				<comment />
				<x>431</x>
				<y>464</y>
			</state>
			<state id="*na1">
				<name>*na1</name>
				<comment />
				<x>203</x>
				<y>417</y>
			</state>
			<state id="q5">
				<name>q5</name>
				<comment />
				<x>779</x>
				<y>445</y>
			</state>
			<state id="q6">
				<name>q6</name>
				<comment />
				<x>908</x>
				<y>259</y>
			</state>
		</states>
		<transitions>
			<transition>
				<from>q0</from>
				<to>q0</to>
				<read>1</read>
				<write>1</write>
				<move>Left</move>
				<comment />
			</transition>
			<transition>
				<from>q0</from>
				<to>q0</to>
				<read>€</read>
				<write>€</write>
				<move>Left</move>
				<comment />
			</transition>
			<transition>
				<from>q0</from>
				<to>q0</to>
				<read>$</read>
				<write>$</write>
				<move>Left</move>
				<comment />
			</transition>
			<transition>
				<from>q0</from>
				<to>q1</to>
				<read>Blank</read>
				<write>Blank</write>
				<move>Right</move>
				<comment />
			</transition>
			<transition>
				<from>q1</from>
				<to>q2</to>
				<read>1</read>
				<write>Blank</write>
				<move>Right</move>
				<comment />
			</transition>
			<transition>
				<from>q1</from>
				<to>qv</to>
				<read>$</read>
				<write>Blank</write>
				<move>Right</move>
				<comment />
			</transition>
			<transition>
				<from>qv</from>
				<to>qv</to>
				<read>1</read>
				<write>Blank</write>
				<move>Right</move>
				<comment />
			</transition>
			<transition>
				<from>qv</from>
				<to>qf</to>
				<read>€</read>
				<write>Blank</write>
				<move>Right</move>
				<comment />
			</transition>
			<transition>
				<from>q2</from>
				<to>q2</to>
				<read>1</read>
				<write>1</write>
				<move>Right</move>
				<comment />
			</transition>
			<transition>
				<from>q2</from>
				<to>q3</to>
				<read>$</read>
				<write>$</write>
				<move>Right</move>
				<comment />
			</transition>
			<transition>
				<from>q3</from>
				<to>q4</to>
				<read>1</read>
				<write>*</write>
				<move>Right</move>
				<comment />
			</transition>
			<transition>
				<from>q3</from>
				<to>*na1</to>
				<read>€</read>
				<write>€</write>
				<move>Left</move>
				<comment />
			</transition>
			<transition>
				<from>*na1</from>
				<to>*na1</to>
				<read>*</read>
				<write>1</write>
				<move>Left</move>
				<comment />
			</transition>
			<transition>
				<from>*na1</from>
				<to>q0</to>
				<read>$</read>
				<write>$</write>
				<move>Left</move>
				<comment />
			</transition>
			<transition>
				<from>q4</from>
				<to>q4</to>
				<read>1</read>
				<write>1</write>
				<move>Right</move>
				<comment />
			</transition>
			<transition>
				<from>q4</from>
				<to>q5</to>
				<read>€</read>
				<write>€</write>
				<move>Right</move>
				<comment />
			</transition>
			<transition>
				<from>q5</from>
				<to>q5</to>
				<read>1</read>
				<write>1</write>
				<move>Right</move>
				<comment />
			</transition>
			<transition>
				<from>q5</from>
				<to>q6</to>
				<read>Blank</read>
				<write>1</write>
				<move>Left</move>
				<comment />
			</transition>
			<transition>
				<from>q6</from>
				<to>q6</to>
				<read>1</read>
				<write>1</write>
				<move>Left</move>
				<comment />
			</transition>
			<transition>
				<from>q6</from>
				<to>q6</to>
				<read>€</read>
				<write>€</write>
				<move>Left</move>
				<comment />
			</transition>
			<transition>
				<from>q6</from>
				<to>q3</to>
				<read>*</read>
				<write>*</write>
				<move>Right</move>
				<comment />
			</transition>
		</transitions>
		<code>//Nastavenie na začiatok vstupu
δ(q0,1)=(q0,1,L)
δ(q0,€)=(q0,€,L)
δ(q0,$)=(q0,$,L)
δ(q0,Blank)=(q1,Blank,R)

δ(q1,1)=(q2,Blank,R)
//Príklad je vypočítaný - zmazanie vstupov, aby zostal len výstup
δ(q1,$)=(qv,Blank,R)
δ(qv,1)=(qv,Blank,R)
//Koniec výpočtu
δ(qv,€)=(qf,Blank,R)

δ(q2,1)=(q2,1,R)
δ(q2,$)=(q3,$,R)

δ(q3,1)=(q4,*,R)
δ(q3,€)=(*na1,€,L)

δ(*na1,*)=(*na1,1,L)
δ(*na1,$)=(q0,$,L)

δ(q4,1)=(q4,1,R)
δ(q4,€)=(q5,€,R)
δ(q5,1)=(q5,1,R)
δ(q5,Blank)=(q6,1,L)

δ(q6,1)=(q6,1,L)
δ(q6,€)=(q6,€,L)
δ(q6,*)=(q3,*,R)

</code>
	</machine>
</turingmachine>