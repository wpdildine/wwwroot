<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ctrl__Overlay_SymbolicChallenge2.ascx.cs" Inherits="App_Controls_ctrl__Overlay_SymbolicChallenge" %>

<div id="evaluation_overlay" class="e_overlay"></div>
<div class="e_overlay_content">

    <div class="back"><a href="#" onclick="HideEvaluationAndGoBack();return false;" class="btn btn_thin_blue"><span>&laquo; Back</span></a></div>


    <h1><span>Sensory:</span> Challenge Example 1</h1>
    <h2>Interactive Evaluation</h2>

    <ol class="ol_gray" style="margin-bottom:30px;">
        <li><span class="num">1</span>Mom’s goal is to help Alex come up with his own ideas. What are ways she can help him to think on his own? 

            <div class="row">
                <input id="q2_a" type="radio" class="rad" name="q2" onchange="showAnswers('q2');return false;" />
                <label for="q2_a">Become a character and describe what ‘she’ wants to do or where she wants to go without telling Alex to do it with her. This gives Alex the freedom to come up with his own response. 
                    <em class="ans q2 correct">By becoming a character, Mom becomes part of the action and gives Alex something to respond to. It is a way to expand the action without directing it because Alex has to decide how to respond to the demands of the character. Whatever Alex’s response, Mom accepts and builds on it. There isn’t any right or wrong answer. </em> </label> 
            </div>
            <div class="row">
                <input id="q2_b" type="radio" class="rad" name="q2" onchange="showAnswers('q2');return false;" />
                <label for="q2_b">Staying outside of the story as Mom, she suggests where they should go in the car.
                    <em class="ans q2">Mom is directing the action. </em> </label> 
            </div>
            <div class="row">
                <input id="q2_c" type="radio" class="rad" name="q2" onchange="showAnswers('q2');return false;" />
                <label for="q2_c">Ask a question to get Alex to think about what to do but when he doesn’t respond quickly, give him a suggestion so that the activity progresses.
                    <em class="ans q2">Mom needs to make sure she has Alex’s attention when she asks a question and then give him time to respond. If he doesn’t respond, she can ask the question in a different way and with more feeling. If she answers her own question to keep the action going, he doesn’t do the thinking.</em> </label> 
            </div>

        </li>
    </ol>

    <a href="#" onclick="HideEvaluation();return false;" class="btn btn_thin_blue"><span>I'm finished with the evaluation</span></a>
    <a href="#" onclick="HideEvaluation();return false;" class="btn btn_cancel">[x] cancel</a>


</div>