<?xml version="1.0" encoding="UTF-8"?>
<turingmachine>
	<meta>
		<author />
		<title>2. Sčítanie unárnych čísel</title>
        <description>Výpočet súčtu dvoch unárnych čísel.</description>
		<created>8. 5. 2026 21:27:53</created>
		<modified>8. 5. 2026 21:28:09</modified>
	</meta>
	<machine type="TM">
		<tapes>
			<tape id="0">
				<head id="0" position="-8" />
				<cell position="-8">1</cell>
				<cell position="-7">1</cell>
				<cell position="-6">1</cell>
				<cell position="-5">1</cell>
				<cell position="-4">+</cell>
				<cell position="-3">1</cell>
				<cell position="-2">1</cell>
				<cell position="-1">1</cell>
				<cell position="0">1</cell>
				<cell position="1">=</cell>
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
				<x>340</x>
				<y>40</y>
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
				<x>640</x>
				<y>40</y>
			</state>
			<state id="q5">
				<name>q5</name>
				<comment />
				<x>40</x>
				<y>190</y>
			</state>
			<state id="g4">
				<name>g4</name>
				<comment />
				<x>190</x>
				<y>190</y>
			</state>
			<state id="q6">
				<name>q6</name>
				<comment />
				<x>340</x>
				<y>190</y>
			</state>
			<state id="q7">
				<name>q7</name>
				<comment />
				<x>490</x>
				<y>190</y>
			</state>
			<state id="qf">
				<name>qf</name>
				<comment />
				<x>640</x>
				<y>190</y>
				<final />
			</state>
			<state id="q8">
				<name>q8</name>
				<comment />
				<x>40</x>
				<y>40</y>
			</state>
		</states>
		<transitions>
			<transition>
				<from>q0</from>
				<to>q1</to>
				<read>1</read>
				<write>1_</write>
				<move>Right</move>
				<comment />
			</transition>
			<transition>
				<from>q0</from>
				<to>q8</to>
				<read>+</read>
				<write>+</write>
				<move>Right</move>
				<comment />
			</transition>
			<transition>
				<from>q1</from>
				<to>q1</to>
				<read>1</read>
				<write>1</write>
				<move>Right</move>
				<comment />
			</transition>
			<transition>
				<from>q1</from>
				<to>q2</to>
				<read>+</read>
				<write>+</write>
				<move>Right</move>
				<comment />
			</transition>
			<transition>
				<from>q2</from>
				<to>q3</to>
				<read>1</read>
				<write>1</write>
				<move>Right</move>
				<comment />
			</transition>
			<transition>
				<from>q3</from>
				<to>q3</to>
				<read>1</read>
				<write>1</write>
				<move>Right</move>
				<comment />
			</transition>
			<transition>
				<from>q3</from>
				<to>q4</to>
				<read>=</read>
				<write>=</write>
				<move>Right</move>
				<comment />
			</transition>
			<transition>
				<from>q4</from>
				<to>q5</to>
				<read>Blank</read>
				<write>1</write>
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
				<from>q5</from>
				<to>q5</to>
				<read>1</read>
				<write>1</write>
				<move>Left</move>
				<comment />
			</transition>
			<transition>
				<from>q5</from>
				<to>q6</to>
				<read>=</read>
				<write>=</write>
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
				<to>q7</to>
				<read>+</read>
				<write>+</write>
				<move>Left</move>
				<comment />
			</transition>
			<transition>
				<from>q7</from>
				<to>q7</to>
				<read>1</read>
				<write>1</write>
				<move>Left</move>
				<comment />
			</transition>
			<transition>
				<from>q7</from>
				<to>q0</to>
				<read>1_</read>
				<write>1_</write>
				<move>Right</move>
				<comment />
			</transition>
			<transition>
				<from>q8</from>
				<to>q2</to>
				<read>1</read>
				<write>1_</write>
				<move>Right</move>
				<comment />
			</transition>
			<transition>
				<from>q6</from>
				<to>q8</to>
				<read>1_</read>
				<write>1_</write>
				<move>Right</move>
				<comment />
			</transition>
			<transition>
				<from>q2</from>
				<to>qf</to>
				<read>=</read>
				<write>=</write>
				<move>Right</move>
				<comment />
			</transition>
		</transitions>
		<code>f (q0, 1) = (q1, 1_, R)
f (q0, +) = (q8, +, R)

f (q1, 1) = (q1, 1, R)
f (q1, +) = (q2, +, R)
f (q2, 1) = (q3, 1, R)
f (q3, 1) = (q3, 1, R)
f (q3, =) = (q4, =, R)

f(q4, Blank) = (q5, 1, L)
f(q4, 1) = (q4, 1, R)

f (q5, 1) = (q5, 1, L)
f (q5, =) = (q6, =, L)
f (q6, 1) = (q6, 1, L)
f (q6, +) = (q7, +, L)
f (q7, 1) = (q7, 1, L)
f (q7, 1_) = (q0, 1_, R)

f(q8, 1) = (q2, 1_, R)
f (q6, 1_) = (q8, 1_, R)
f (q2, =) = (qf, =, R)</code>
	</machine>
</turingmachine>