<?xml version="1.0" encoding="UTF-8"?>
<turingmachine>
	<meta>
		<author />
		<title>1. Slová tvaru a^n b^2n</title>
        <description>Rozpoznávanie slov, kde počet symbolov b je dvojnásobný oproti počtu symbolov a</description>
		<created>8. 5. 2026 21:23:38</created>
		<modified>8. 5. 2026 21:24:45</modified>
	</meta>
	<machine type="TM">
		<tapes>
			<tape id="0">
				<head id="0" position="-8" />
				<cell position="-8">a</cell>
				<cell position="-7">a</cell>
				<cell position="-6">a</cell>
				<cell position="-5">a</cell>
				<cell position="-4">b</cell>
				<cell position="-3">b</cell>
				<cell position="-2">b</cell>
				<cell position="-1">b</cell>
				<cell position="0">b</cell>
				<cell position="1">b</cell>
				<cell position="2">b</cell>
				<cell position="3">b</cell>
			</tape>
		</tapes>
		<states>
			<state id="q1">
				<name>q1</name>
				<comment />
				<x>40</x>
				<y>40</y>
			</state>
			<state id="q0">
				<name>q0</name>
				<comment />
				<x>190</x>
				<y>40</y>
				<initial />
			</state>
			<state id="q2">
				<name>q2</name>
				<comment />
				<x>260</x>
				<y>287</y>
			</state>
			<state id="q3">
				<name>q3</name>
				<comment />
				<x>490</x>
				<y>40</y>
			</state>
			<state id="q4">
				<name>q4</name>
				<comment />
				<x>667</x>
				<y>177</y>
			</state>
			<state id="qf">
				<name>qf</name>
				<comment />
				<x>544</x>
				<y>251</y>
				<final />
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
				<from>q1</from>
				<to>q1</to>
				<read>a</read>
				<write>a</write>
				<move>Right</move>
				<comment />
			</transition>
			<transition>
				<from>q1</from>
				<to>q3</to>
				<read>b</read>
				<write>b_</write>
				<move>Right</move>
				<comment />
			</transition>
			<transition>
				<from>q1</from>
				<to>q2</to>
				<read>b_</read>
				<write>b_</write>
				<move>Right</move>
				<comment />
			</transition>
			<transition>
				<from>q2</from>
				<to>q2</to>
				<read>b_</read>
				<write>b_</write>
				<move>Right</move>
				<comment />
			</transition>
			<transition>
				<from>q2</from>
				<to>q3</to>
				<read>b</read>
				<write>b_</write>
				<move>Right</move>
				<comment />
			</transition>
			<transition>
				<from>q3</from>
				<to>q4</to>
				<read>b</read>
				<write>b_</write>
				<move>Left</move>
				<comment />
			</transition>
			<transition>
				<from>q4</from>
				<to>q4</to>
				<read>b_</read>
				<write>b_</write>
				<move>Left</move>
				<comment />
			</transition>
			<transition>
				<from>q4</from>
				<to>q4</to>
				<read>a</read>
				<write>a</write>
				<move>Left</move>
				<comment />
			</transition>
			<transition>
				<from>q4</from>
				<to>q0</to>
				<read>a_</read>
				<write>a_</write>
				<move>Right</move>
				<comment />
			</transition>
			<transition>
				<from>q0</from>
				<to>q2</to>
				<read>b_</read>
				<write>b_</write>
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
		</transitions>
		<code>// prechody do prava 
f (q0,a) = (q1,a_,R)
f (q1,a) = (q1,a,R)
f (q1,b) = (q3,b_,R)
f (q1,b_) = (q2,b_,R)
f (q2,b_) = (q2,b_,R)

f (q2,b) = (q3,b_,R)
f (q3,b) = (q4,b_,L)


// Prechody do lava
f (q4,b_) = (q4,b_,L)
f (q4,a) = (q4,a,L)
f (q4,a_) = (q0,a_,R)


// Koniec
f (q0,b_) = (q2,b_,R)
f (q2,Blank) = (qf,Blank,R)
</code>
	</machine>
</turingmachine>