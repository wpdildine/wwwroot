<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ctrl__Overlay_ObjectChallenge1.ascx.cs" Inherits="App_Controls_ctrl__Overlay_ObjectChallenge" %>

<div id="evaluation_overlay" class="e_overlay"></div>
<div class="e_overlay_content">

    <div class="back"><a href="#" onclick="HideEvaluationAndGoBack();return false;" class="btn btn_thin_blue"><span>&laquo; Back</span></a></div>


    <h1><span>Sensory:</span> Challenge Example 1</h1>
    <h2>Interactive Evaluation</h2>

    <ol class="ol_gray" style="margin-bottom:30px;">
        <li><span class="num">1</span>How could Dad extend this play?

            <div class="row">
                <input id="q1_a" type="radio" class="rad" name="q1" onchange="showAnswers('q1');return false;" />
                <label for="q1_a">Tell Alex what he wants to eat next. 
                    <em class="ans q1">Alex is not in charge and Dad is directing him and doing the thinking for him.</em> </label> 
            </div>
            <div class="row">
                <input id="q1_b" type="radio" class="rad" name="q1" onchange="showAnswers('q1');return false;" />
                <label for="q1_b">Tell Alex to feed some cookies to Mom.
                    <em class="ans q1">Alex is not in charge and Dad is directing him and doing the thinking for him.</em> </label> 
            </div>
            <div class="row">
                <input id="q1_c" type="radio" class="rad" name="q1" onchange="showAnswers('q1');return false;" />
                <label for="q1_c">Pretend to not like the cookie and playfully pretend to still be hungry. 
                    <em class="ans q1 correct">Dad puts Alex in charge, making Alex decide what to offer Dad next.</em> </label> 
            </div>

        </li>
    </ol>

    <a href="#" onclick="HideEvaluation();return false;" class="btn btn_thin_blue"><span>I'm finished with the evaluation</span></a>
    <a href="#" onclick="HideEvaluation();return false;" class="btn btn_cancel">[x] cancel</a>


</div>