<?xml version="1.0" encoding="UTF-8"?>
<turingmachine>
	<meta>
		<author />
		<title />
		<description />
		<created>9. 6. 2008 12:50:55</created>
		<modified>9. 6. 2008 12:50:55</modified>
	</meta>
	<machine type="TM">
		<tapes>
			<tape id="0">
				<head id="0" position="-3" />
				<cell position="-8">Blue</cell>
				<cell position="-7">Blue</cell>
				<cell position="-6">Yellow</cell>
				<cell position="-5">Red</cell>
				<cell position="-4">Red</cell>
				<cell position="-3">Green</cell>
				<cell position="-2">Blue</cell>
				<cell position="-1">Green</cell>
				<cell position="0">Green</cell>
				<cell position="1">Yellow</cell>
				<cell position="2">Red</cell>
			</tape>
		</tapes>
		<states>
			<state id="q0">
				<name>q0</name>
				<comment />
				<x>73</x>
				<y>108</y>
				<initial />
			</state>
			<state id="qf">
				<name>qf</name>
				<comment />
				<x>716</x>
				<y>228</y>
				<final />
			</state>
			<state id="q1">
				<name>q1</name>
				<comment />
				<x>288</x>
				<y>198</y>
			</state>
			<state id="q2">
				<name>q2</name>
				<comment />
				<x>442</x>
				<y>136</y>
			</state>
			<state id="qprva">
				<name>qprva</name>
				<comment />
				<x>137</x>
				<y>345</y>
			</state>
		</states>
		<transitions>
			<transition>
				<from>q0</from>
				<to>q0</to>
				<read>farba</read>
				<write>farba</write>
				<move>Left</move>
				<comment />
			</transition>
			<transition>
				<from>q1</from>
				<to>q1</to>
				<read>Blue</read>
				<write>Yellow</write>
				<move>Right</move>
				<comment />
			</transition>
			<transition>
				<from>q1</from>
				<to>q1</to>
				<read>Yellow</read>
				<write>Blue</write>
				<move>Right</move>
				<comment />
			</transition>
			<transition>
				<from>q1</from>
				<to>q1</to>
				<read>Red</read>
				<write>Green</write>
				<move>Right</move>
				<comment />
			</transition>
			<transition>
				<from>q1</from>
				<to>q1</to>
				<read>Green</read>
				<write>Red</write>
				<move>Right</move>
				<comment />
			</transition>
			<transition>
				<from>q1</from>
				<to>q2</to>
				<read>farba</read>
				<write>Black</write>
				<move>Right</move>
				<comment />
			</transition>
			<transition>
				<from>q2</from>
				<to>qf</to>
				<read>Blank</read>
				<write>Blank</write>
				<move>Right</move>
				<comment />
			</transition>
			<transition>
				<from>q0</from>
				<to>qprva</to>
				<read>farba</read>
				<write>Black</write>
				<move>Left</move>
				<comment />
			</transition>
			<transition>
				<from>qprva</from>
				<to>q1</to>
				<read>Blank</read>
				<write>Blank</write>
				<move>Right</move>
				<comment />
			</transition>
			<transition>
				<from>q1</from>
				<to>q1</to>
				<read>Black</read>
				<write>Black</write>
				<move>Right</move>
				<comment />
			</transition>
		</transitions>
		<code>// Program: Zmena farieb
// Prvu a poslednu farbu zmeni na ciernu,
// farby uprostred zmeni tak, 
// ze vymeni zelenu s cervenou a modru so zltou

farba={Red, Blue, Green, Yellow, Black}

δ (q0,farba) = (q0,farba,L) 
δ (q1,Blue) = (q1,Yellow,R) 
δ (q1,Yellow) = (q1,Blue,R)
δ (q1,Red) = (q1,Green,R) 
δ (q1,Green) = (q1,Red,R) 
δ (q1,farba) = (q2,Black,R) 
δ (q2,Blank) = (qf,Blank,R) 
δ (q0,farba) = (qprva,Black,L) 
δ (qprva,Blank) = (q1,Blank,R) 
δ (q1,Black) = (q1,Black,R) 
</code>
	</machine>
</turingmachine>