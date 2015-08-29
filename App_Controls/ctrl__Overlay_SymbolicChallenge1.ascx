<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ctrl__Overlay_SymbolicChallenge1.ascx.cs" Inherits="App_Controls_ctrl__Overlay_SymbolicChallenge" %>

<div id="evaluation_overlay" class="e_overlay"></div>
<div class="e_overlay_content">

    <div class="back"><a href="#" onclick="HideEvaluationAndGoBack();return false;" class="btn btn_thin_blue"><span>&laquo; Back</span></a></div>


    <h1><span>Sensory:</span> Challenge Example 1</h1>
    <h2>Interactive Evaluation</h2>

    <ol class="ol_gray" style="margin-bottom:30px;">
        <li><span class="num">1</span>If the play had continued, what could Mom have done next to keep the action going? 

            <div class="row">
                <input id="q1_a" type="radio" class="rad" name="q1" onchange="showAnswers('q1');return false;" />
                <label for="q1_a">Ask a question such as “who else is going into the castle?”
                    <em class="ans q1">This seems like an acceptable response but has a couple of problems. Since Cole is interested in the princess, it shifts the focus. It also may be difficult for Cole to answer because of his level of development. </em> </label> 
            </div>
            <div class="row">
                <input id="q1_b" type="radio" class="rad" name="q1" onchange="showAnswers('q1');return false;" />
                <label for="q1_b">Become a character and say she wants to go into the castle.
                    <em class="ans q1 correct">Becoming a character lets Mom become a part of the drama and helps to expand it. Cole then has to response to Mom’s character by communicating with her.</em> </label> 
            </div>
            <div class="row">
                <input id="q1_c" type="radio" class="rad" name="q1" onchange="showAnswers('q1');return false;" />
                <label for="q1_c">Say, “Let’s go into the castle and find the princess.”
                    <em class="ans q1">This kind of statement directs the play. Giving these types of suggestions makes the task of expanding the play fairly simple for the child because the adult is doing the thinking. It does allow the story to go forward. But the adult is driving the progression. To improve the child’s planning and creativity, the child should come up with the next step.</em> </label> 
            </div>

        </li>
    </ol>

    <a href="#" onclick="HideEvaluation();return false;" class="btn btn_thin_blue"><span>I'm finished with the evaluation</span></a>
    <a href="#" onclick="HideEvaluation();return false;" class="btn btn_cancel">[x] cancel</a>


</div>