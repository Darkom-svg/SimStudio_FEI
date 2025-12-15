<?xml version="1.0" encoding="UTF-8"?>
<turingmachine>
	<meta>
		<author />
		<title />
		<description />
		<created>15. 5. 2008 23:55:31</created>
		<modified>15. 5. 2008 23:55:31</modified>
	</meta>
	<machine type="TM">
		<tapes>
			<tape id="0">
				<head id="0" position="-9" />
				<cell position="-9">a</cell>
				<cell position="-8">b</cell>
				<cell position="-7">b</cell>
				<cell position="-6">b</cell>
				<cell position="-5">c</cell>
				<cell position="-4">a</cell>
				<cell position="-3">c</cell>
				<cell position="-2">c</cell>
				<cell position="-1">a</cell>
			</tape>
		</tapes>
		<states>
			<state id="q0">
				<name>q0</name>
				<comment />
				<x>76</x>
				<y>116</y>
				<initial />
			</state>
			<state id="q1">
				<name>q1</name>
				<comment />
				<x>298</x>
				<y>120</y>
			</state>
			<state id="q2">
				<name>q2</name>
				<comment />
				<x>514</x>
				<y>109</y>
			</state>
			<state id="q3">
				<name>q3</name>
				<comment />
				<x>714</x>
				<y>122</y>
			</state>
			<state id="q4">
				<name>q4</name>
				<comment />
				<x>649</x>
				<y>320</y>
			</state>
			<state id="q5">
				<name>q5</name>
				<comment />
				<x>254</x>
				<y>286</y>
			</state>
			<state id="qk">
				<name>qk</name>
				<comment />
				<x>92</x>
				<y>406</y>
			</state>
			<state id="qf">
				<name>qf</name>
				<comment />
				<x>472</x>
				<y>413</y>
				<final />
			</state>
		</states>
		<transitions>
			<transition>
				<from>q0</from>
				<to>q0</to>
				<read>x</read>
				<write>x</write>
				<move>Right</move>
				<comment />
			</transition>
			<transition>
				<from>q0</from>
				<to>q1</to>
				<read>a</read>
				<write>a_</write>
				<move>Left</move>
				<comment />
			</transition>
			<transition>
				<from>q1</from>
				<to>q1</to>
				<read>x</read>
				<write>x</write>
				<move>Left</move>
				<comment />
			</transition>
			<transition>
				<from>q1</from>
				<to>q2</to>
				<read>Blank</read>
				<write>Blank</write>
				<move>Right</move>
				<comment />
			</transition>
			<transition>
				<from>q2</from>
				<to>q2</to>
				<read>y</read>
				<write>y</write>
				<move>Right</move>
				<comment />
			</transition>
			<transition>
				<from>q2</from>
				<to>q3</to>
				<read>b</read>
				<write>b_</write>
				<move>Left</move>
				<comment />
			</transition>
			<transition>
				<from>q3</from>
				<to>q3</to>
				<read>y</read>
				<write>y</write>
				<move>Left</move>
				<comment />
			</transition>
			<transition>
				<from>q3</from>
				<to>q4</to>
				<read>Blank</read>
				<write>Blank</write>
				<move>Right</move>
				<comment />
			</transition>
			<transition>
				<from>q4</from>
				<to>q4</to>
				<read>z</read>
				<write>z</write>
				<move>Right</move>
				<comment />
			</transition>
			<transition>
				<from>q4</from>
				<to>q5</to>
				<read>c</read>
				<write>c_</write>
				<move>Left</move>
				<comment />
			</transition>
			<transition>
				<from>q5</from>
				<to>q5</to>
				<read>z</read>
				<write>z</write>
				<move>Left</move>
				<comment />
			</transition>
			<transition>
				<from>q5</from>
				<to>q0</to>
				<read>Blank</read>
				<write>Blank</write>
				<move>Right</move>
				<comment />
			</transition>
			<transition>
				<from>q0</from>
				<to>qk</to>
				<read>Blank</read>
				<write>Blank</write>
				<move>Left</move>
				<comment />
			</transition>
			<transition>
				<from>qk</from>
				<to>qk</to>
				<read>v</read>
				<write>v</write>
				<move>Right</move>
				<comment />
			</transition>
			<transition>
				<from>qk</from>
				<to>qf</to>
				<read>Blank</read>
				<write>Blank</write>
				<move>Right</move>
				<comment />
			</transition>
		</transitions>
		<code>//Definujte Turingov stroj, ktorý rozpoznáva jazyk 
//L = {#aw = #bw = #cw | w = {a, b, c}*}

//Hľadá symbol a, stav q0
δ(q0,x) = (q0,x,R); x={a_, b, b_, c, c_}
δ(q0,a) = (q1,a_,L)
δ(q1,x) = (q1,x,L)
δ(q1,Blank) = (q2,Blank,R)

//Hľadá symbol b, stav q2
δ(q2,y) = (q2,y,R); y={a, a_, b_, c, c_}
δ(q2,b) = (q3,b_,L)
δ(q3,y) = (q3,y,L)
δ(q3,Blank) = (q4,Blank,R)

//Hľadá symbol c, stav q4
δ(q4,z) = (q4,z,R); z={a, a_, b, b_, c_}
δ(q4,c) = (q5,c_,L)
δ(q5,z) = (q5,z,L)
δ(q5,Blank) = (q0,Blank,R)

//Kontrola, stav qk
δ(q0,Blank) = (qk,Blank,L)
δ(qk,v) = (qk,v,R); v={a_, b_, c_}
δ(qk,Blank) = (qf,Blank,R)</code>
	</machine>
</turingmachine>