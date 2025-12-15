<?xml version="1.0" encoding="UTF-8"?>
<turingmachine>
	<meta>
		<author />
		<title />
		<description />
		<created>15. 5. 2008 23:57:35</created>
		<modified>15. 5. 2008 23:57:35</modified>
	</meta>
	<machine type="TM">
		<tapes>
			<tape id="0">
				<head id="0" position="-7" />
				<cell position="-7">b</cell>
				<cell position="-6">a</cell>
				<cell position="-5">a</cell>
				<cell position="-4">b</cell>
				<cell position="-3">b</cell>
				<cell position="-2">a</cell>
				<cell position="-1">a</cell>
				<cell position="0">b</cell>
			</tape>
		</tapes>
		<states>
			<state id="q1">
				<name>q1</name>
				<comment />
				<x>303</x>
				<y>148</y>
			</state>
			<state id="q0">
				<name>q0</name>
				<comment />
				<x>259</x>
				<y>238</y>
				<initial />
			</state>
			<state id="q2">
				<name>q2</name>
				<comment />
				<x>558</x>
				<y>94</y>
			</state>
			<state id="q3">
				<name>q3</name>
				<comment />
				<x>681</x>
				<y>144</y>
			</state>
			<state id="q4">
				<name>q4</name>
				<comment />
				<x>872</x>
				<y>37</y>
			</state>
			<state id="q5">
				<name>q5</name>
				<comment />
				<x>462</x>
				<y>239</y>
			</state>
			<state id="qa">
				<name>qa</name>
				<comment />
				<x>1060</x>
				<y>372</y>
			</state>
			<state id="qa'">
				<name>qa'</name>
				<comment />
				<x>813</x>
				<y>461</y>
			</state>
			<state id="qt">
				<name>qt</name>
				<comment />
				<x>309</x>
				<y>425</y>
			</state>
			<state id="qa''">
				<name>qa''</name>
				<comment />
				<x>628</x>
				<y>461</y>
			</state>
			<state id="qt'">
				<name>qt'</name>
				<comment />
				<x>560</x>
				<y>327</y>
			</state>
			<state id="qk">
				<name>qk</name>
				<comment />
				<x>159</x>
				<y>453</y>
			</state>
			<state id="qf">
				<name>qf</name>
				<comment />
				<x>30</x>
				<y>255</y>
				<final />
			</state>
			<state id="qt''">
				<name>qt''</name>
				<comment />
				<x>187</x>
				<y>298</y>
			</state>
			<state id="qb">
				<name>qb</name>
				<comment />
				<x>904</x>
				<y>328</y>
			</state>
			<state id="qb'">
				<name>qb'</name>
				<comment />
				<x>715</x>
				<y>324</y>
			</state>
			<state id="qb''">
				<name>qb''</name>
				<comment />
				<x>602</x>
				<y>385</y>
			</state>
			<state id="q4'">
				<name>q4'</name>
				<comment />
				<x>46</x>
				<y>31</y>
			</state>
		</states>
		<transitions>
			<transition>
				<from>q0</from>
				<to>q1</to>
				<read>x</read>
				<write>x_</write>
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
				<read>y</read>
				<write>y</write>
				<move>Left</move>
				<comment />
			</transition>
			<transition>
				<from>q2</from>
				<to>q3</to>
				<read>x</read>
				<write>x_</write>
				<move>Left</move>
				<comment />
			</transition>
			<transition>
				<from>q3</from>
				<to>q4</to>
				<read>x_</read>
				<write>x_</write>
				<move>Right</move>
				<comment />
			</transition>
			<transition>
				<from>q3</from>
				<to>q5</to>
				<read>x</read>
				<write>x</write>
				<move>Left</move>
				<comment />
			</transition>
			<transition>
				<from>q5</from>
				<to>q5</to>
				<read>x</read>
				<write>x</write>
				<move>Left</move>
				<comment />
			</transition>
			<transition>
				<from>q5</from>
				<to>q0</to>
				<read>x_</read>
				<write>x_</write>
				<move>Right</move>
				<comment />
			</transition>
			<transition>
				<from>q4</from>
				<to>qa</to>
				<read>a_</read>
				<write>A_</write>
				<move>Left</move>
				<comment />
			</transition>
			<transition>
				<from>qa</from>
				<to>qa</to>
				<read>X_</read>
				<write>X_</write>
				<move>Left</move>
				<comment />
			</transition>
			<transition>
				<from>qa</from>
				<to>qa'</to>
				<read>x_</read>
				<write>x_</write>
				<move>Left</move>
				<comment />
			</transition>
			<transition>
				<from>qa'</from>
				<to>qa'</to>
				<read>x_</read>
				<write>x_</write>
				<move>Left</move>
				<comment />
			</transition>
			<transition>
				<from>qa'</from>
				<to>qa''</to>
				<read>z_</read>
				<write>z_</write>
				<move>Right</move>
				<comment />
			</transition>
			<transition>
				<from>qa''</from>
				<to>qt</to>
				<read>a_</read>
				<write>A_</write>
				<move>Right</move>
				<comment />
			</transition>
			<transition>
				<from>qt</from>
				<to>qt'</to>
				<read>x_</read>
				<write>x_</write>
				<move>Right</move>
				<comment />
			</transition>
			<transition>
				<from>qt'</from>
				<to>qt'</to>
				<read>x_</read>
				<write>x_</write>
				<move>Right</move>
				<comment />
			</transition>
			<transition>
				<from>qt</from>
				<to>qk</to>
				<read>X_</read>
				<write>X_</write>
				<move>Right</move>
				<comment />
			</transition>
			<transition>
				<from>qk</from>
				<to>qk</to>
				<read>X_</read>
				<write>X_</write>
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
			<transition>
				<from>qt'</from>
				<to>qt''</to>
				<read>X_</read>
				<write>X_</write>
				<move>Right</move>
				<comment />
			</transition>
			<transition>
				<from>qt''</from>
				<to>qt''</to>
				<read>X_</read>
				<write>X_</write>
				<move>Right</move>
				<comment />
			</transition>
			<transition>
				<from>qt''</from>
				<to>q4'</to>
				<read>x_</read>
				<write>x_</write>
				<move>Left</move>
				<comment />
			</transition>
			<transition>
				<from>q4'</from>
				<to>q4</to>
				<read>X_</read>
				<write>X_</write>
				<move>Right</move>
				<comment />
			</transition>
			<transition>
				<from>q4</from>
				<to>qb</to>
				<read>b_</read>
				<write>B_</write>
				<move>Left</move>
				<comment />
			</transition>
			<transition>
				<from>qb</from>
				<to>qb</to>
				<read>X_</read>
				<write>X_</write>
				<move>Left</move>
				<comment />
			</transition>
			<transition>
				<from>qb</from>
				<to>qb'</to>
				<read>x_</read>
				<write>x_</write>
				<move>Left</move>
				<comment />
			</transition>
			<transition>
				<from>qb'</from>
				<to>qb'</to>
				<read>x_</read>
				<write>x_</write>
				<move>Left</move>
				<comment />
			</transition>
			<transition>
				<from>qb'</from>
				<to>qb''</to>
				<read>z_</read>
				<write>z_</write>
				<move>Right</move>
				<comment />
			</transition>
			<transition>
				<from>qb''</from>
				<to>qt</to>
				<read>b_</read>
				<write>B_</write>
				<move>Right</move>
				<comment />
			</transition>
		</transitions>
		<code>//Turingov stroj, ktorý rozpoznáva jazyk L = {ww | w = {a, b, c}}

x = {a,b}; x_ = {a_,b_}
X = {A,B}; X_ = {A_,B_}

δ(q0, x) = (q1, x_, R)
δ(q1, x) = (q1, x, R)
δ(q1, y) = (q2, y, L); y = {Blank,a_,b_}
δ(q2, x) = (q3, x_, L)
δ(q3, x_) = (q4, x_, R)
δ(q3, x) = (q5, x, L)
δ(q5, x) = (q5, x, L)
δ(q5, x_) = (q0, x_, R)

//našiel stred vstupného slova v stave q4
//kontroluje rovnosť slov w, začína v strede v stave q4
//kontrola symbolu a, zapamätávanie symbolu v stave qa
δ(q4, a_) = (qa, A_, L)
δ(qa, X_) = (qa, X_, L)
δ(qa, x_) = (qa', x_, L)
δ(qa', x_) = (qa', x_, L)
δ(qa', z_) = (qa'',z_, R); z = {Blank,A_,B_}; z_ = {Blank,A_,B_}
δ(qa'', a_) = (qt,A_,R)

δ(qt, x_) = (qt',x_,R)
δ(qt', x_) = (qt',x_,R)
δ(qt,X_) = (qk,X_,R)
δ(qk,X_) = (qk,X_,R)
δ(qk,Blank) = (qf ,Blank,R)
δ(qt',X_) = (qt'',X_,R)
δ(qt'',X_) = (qt'',X_,R)

δ(qt'',x_) = (q4',x_,L)
δ(q4',X_) = (q4,X_,R)

//kontrola symbolu b, zapamätávanie symbolu v stave qb
δ(q4, b_) = (qb, B_, L)
δ(qb, X_) = (qb, X_, L)
δ(qb, x_) = (qb', x_, L)
δ(qb', x_) = (qb', x_, L)
δ(qb', z_) = (qb'', z_, R)
δ(qb'', b_) = (qt, B_, R)

</code>
	</machine>
</turingmachine>