<?xml version="1.0" encoding="UTF-8"?>
<turingmachine>
	<meta>
		<author />
		<title />
		<description />
		<created>15. 5. 2008 23:53:25</created>
		<modified>15. 5. 2008 23:53:25</modified>
	</meta>
	<machine type="TM">
		<tapes>
			<tape id="0">
				<head id="0" position="-7" />
				<cell position="-7">a</cell>
				<cell position="-6">a</cell>
				<cell position="-5">a</cell>
				<cell position="-4">a</cell>
				<cell position="-3">b</cell>
				<cell position="-2">b</cell>
				<cell position="-1">b</cell>
				<cell position="0">b</cell>
				<cell position="1">c</cell>
				<cell position="2">c</cell>
				<cell position="3">c</cell>
				<cell position="4">c</cell>
			</tape>
		</tapes>
		<states>
			<state id="q1">
				<name>q1</name>
				<comment />
				<x>59</x>
				<y>204</y>
			</state>
			<state id="q0">
				<name>q0</name>
				<comment />
				<x>298</x>
				<y>405</y>
				<initial />
			</state>
			<state id="q2">
				<name>q2</name>
				<comment />
				<x>302</x>
				<y>204</y>
			</state>
			<state id="q3">
				<name>q3</name>
				<comment />
				<x>491</x>
				<y>234</y>
			</state>
			<state id="q4">
				<name>q4</name>
				<comment />
				<x>748</x>
				<y>297</y>
			</state>
			<state id="qk">
				<name>qk</name>
				<comment />
				<x>611</x>
				<y>118</y>
			</state>
			<state id="qf">
				<name>qf</name>
				<comment />
				<x>820</x>
				<y>123</y>
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
				<read>x</read>
				<write>x</write>
				<move>Right</move>
				<comment />
			</transition>
			<transition>
				<from>q1</from>
				<to>q2</to>
				<read>b</read>
				<write>b_</write>
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
				<read>c</read>
				<write>c_</write>
				<move>Left</move>
				<comment />
			</transition>
			<transition>
				<from>q3</from>
				<to>q3</to>
				<read>z</read>
				<write>z</write>
				<move>Left</move>
				<comment />
			</transition>
			<transition>
				<from>q3</from>
				<to>q4</to>
				<read>a</read>
				<write>a</write>
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
				<from>q3</from>
				<to>q0</to>
				<read>a_</read>
				<write>a_</write>
				<move>Right</move>
				<comment />
			</transition>
			<transition>
				<from>q3</from>
				<to>qk</to>
				<read>a_</read>
				<write>a_</write>
				<move>Right</move>
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
				<from>qk</from>
				<to>qk</to>
				<read>w</read>
				<write>w</write>
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
		<code>//Turingov stroj, ktorý rozpoznáva jazyk L2 = {a^n.b^n.c^n | n = N+}

δ(q0, a) = (q1, a_, R)
δ(q1, x) = (q1, x, R); x = {a, b_}
δ(q1, b) = (q2, b_, R)
δ(q2, y) = (q2, y, R); y = {b, c_}
δ(q2, c) = (q3, c_, L)
δ(q3, z) = (q3, z, L); z = {c_, b, b_}
δ(q3, a) = (q4, a, L)
δ(q4, a) = (q4, a, L)
δ(q3, a_) = (q0, a_, R)
δ(q3, a_) = (qk, a_, R)
δ(q4, a_) = (q0, a_, R)
δ(qk, w) = (qk, w, R); w = {b_, c_}
δ(qk, Blank) = (qf, Blank, R)
</code>
	</machine>
</turingmachine>