﻿<number 
  label="Q1"
  optional="0"
  showSource="1"
  size="3"
  verify="range(0,99)">
  <title>What is your age?</title>
  <comment>${res.defresCommentNum}</comment>
  <noanswer label="n99">Prefer not to answer</noanswer>
</number>

<suspend/>

<term label="Q1_Term" cond="not Q1.inrange(18,85)">Q1: Not in required age range</term>

<radio 
  label="xQ1"
  showSource="1"
  where="execute,survey,report">
  <title>Hidden question: Stores age</title>
  <exec>
rangerec(Q1,xQ1)
  </exec>

  <row label="r1">18-24</row>
  <row label="r2">25-29</row>
  <row label="r3">30-34</row>
  <row label="r4">35-39</row>
  <row label="r5">40-44</row>
  <row label="r6">45-49</row>
  <row label="r7">50-54</row>
  <row label="r8">55-59</row>
  <row label="r9">60-64</row>
  <row label="r10">65-85</row>
</radio>

<suspend/>

<radio 
  label="Q2"
  showSource="1"
  values="order">
  <title>What gender do you identify with?</title>
  <comment>${res.defresSC}</comment>
  <row label="r1" value="1">Male</row>
  <row label="r2" value="2">Female</row>
  <row label="r3" value="3">Gender diverse</row>
  <row label="r98" value="98">Other</row>
</radio>

<suspend/>

<term label="Q2_Term" cond="Q2.r98">Q2: Other gender</term>