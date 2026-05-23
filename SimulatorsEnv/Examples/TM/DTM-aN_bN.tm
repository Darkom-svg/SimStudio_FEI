<?xml version="1.0" encoding="UTF-8"?>
<turingmachine>
	<meta>
		<author />
		<title>1. Slová tvaru a^n b^n</title>
        <description>Rozpoznávanie slov, kde počet symbolov b je rovnaký ako počet symbolov a</description>
		<created>23. 5. 2026 18:07:52</created>
		<modified>23. 5. 2026 18:08:19</modified>
	</meta>
	<machine type="TM">
		<tapes>
			<tape id="0">
				<head id="0" position="0" />
				<cell position="0">a</cell>
				<cell position="1">a</cell>
				<cell position="2">b</cell>
				<cell position="3">b</cell>
			</tape>
		</tapes>
		<states>
			<state id="q0">
				<name>q0</name>
				<comment />
				<x>284</x>
				<y>44</y>
				<initial />
			</state>
			<state id="qf">
				<name>qf</name>
				<comment />
				<x>911</x>
				<y>188</y>
				<final />
			</state>
			<state id="q1">
				<name>q1</name>
				<comment />
				<x>604</x>
				<y>65</y>
			</state>
			<state id="q5">
				<name>q5</name>
				<comment />
				<x>112</x>
				<y>144</y>
			</state>
			<state id="q2">
				<name>q2</name>
				<comment />
				<x>740</x>
				<y>208</y>
			</state>
			<state id="q3">
				<name>q3</name>
				<comment />
				<x>514</x>
				<y>244</y>
			</state>
			<state id="q4">
				<name>q4</name>
				<comment />
				<x>368</x>
				<y>257</y>
			</state>
		</states>
		<transitions>
			<transition>
				<from>q0</from>
				<to>q1</to>
				<read>a</read>
				<write>a_</write>
				<move>Right</move>
				<comment />
			</transition>
			<transition>
				<from>q0</from>
				<to>q5</to>
				<read>b_</read>
				<write>b_</write>
				<move>Right</move>
				<comment />
			</transition>
			<transition>
				<from>q0</from>
				<to>qf</to>
				<read>Blank</read>
				<write>Blank</write>
				<move>NoMove</move>
				<comment />
			</transition>
			<transition>
				<from>q1</from>
				<to>q1</to>
				<read>a</read>
				<write>a</write>
				<move>Right</move>
				<comment />
			</transition>
			<transition>
				<from>q1</from>
				<to>q1</to>
				<read>b_</read>
				<write>b_</write>
				<move>Right</move>
				<comment />
			</transition>
			<transition>
				<from>q1</from>
				<to>q2</to>
				<read>b</read>
				<write>b_</write>
				<move>Left</move>
				<comment />
			</transition>
			<transition>
				<from>q2</from>
				<to>q2</to>
				<read>a</read>
				<write>a</write>
				<move>Left</move>
				<comment />
			</transition>
			<transition>
				<from>q2</from>
				<to>q2</to>
				<read>b_</read>
				<write>b_</write>
				<move>Left</move>
				<comment />
			</transition>
			<transition>
				<from>q2</from>
				<to>q0</to>
				<read>a_</read>
				<write>a_</write>
				<move>Right</move>
				<comment />
			</transition>
			<transition>
				<from>q5</from>
				<to>q5</to>
				<read>b_</read>
				<write>b_</write>
				<move>Right</move>
				<comment />
			</transition>
			<transition>
				<from>q5</from>
				<to>qf</to>
				<read>Blank</read>
				<write>Blank</write>
				<move>NoMove</move>
				<comment />
			</transition>
		</transitions>
		<code>// Označenie prvého neoznačeného a
            δ(q0,a) = (q1,a_,R)
            
            // Ak už nie je žiadne a, kontrolujem zvyšok slova
            δ(q0,b_) = (q5,b_,R)
            δ(q0,Blank) = (qf,Blank,0)
            
            // Prejdenie cez a
            δ(q1,a) = (q1,a,R)
            δ(q1,b_) = (q1,b_,R)
            
            // Nájdenie prvého neoznačeného b
            δ(q1,b) = (q2,b_,L)
            
            // Návrat späť na začiatok
            δ(q2,a) = (q2,a,L)
            δ(q2,b_) = (q2,b_,L)
            δ(q2,a_) = (q0,a_,R)
            
            // Kontrola, či už ostali iba označené b
            δ(q5,b_) = (q5,b_,R)
            δ(q5,Blank) = (qf,Blank,0)
        </code>
	</machine>
</turingmachine>