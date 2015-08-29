<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ctrl__Overlay_YourFT.ascx.cs" Inherits="App_Controls_ctrl__Overlay_ObjectFollowTheLead" %>

<div id="evaluation_overlay" class="e_overlay"></div>
<div class="e_overlay_content">

    <div class="back"><a href="#" onclick="HideEvaluationAndGoBack();return false;" class="btn btn_thin_blue"><span>&laquo; Back</span></a></div>


    <h1>Your Floortime Session</h1>
    <h2>Interactive Evaluation</h2>

    <ol class="ol_gray" style="margin-bottom:30px;">
        <li><span class="num">1</span>Did the child initiate/pick the activity?  

            <div class="row">
                <input id="q1_a" type="radio" class="rad" name="q1" onchange="showAnswers('q1');return false;" />
                <label for="q1_a">100-90%
                    <em class="ans q1">INCORRECT!</em> </label> 
            </div>
            <div class="row">
                <input id="q1_b" type="radio" class="rad" name="q1" onchange="showAnswers('q1');return false;" />
                <label for="q1_b">Greater than 50%
                    <em class="ans q1 correct">CORRECT! (maybe at 90%)</em> </label> 
            </div>
            <div class="row">
                <input id="q1_c" type="radio" class="rad" name="q1" onchange="showAnswers('q1');return false;" />
                <label for="q1_c">50%
                    <em class="ans q1">INCORRECT!</em> </label> 
            </div>
            <div class="row">
                <input id="q1_d" type="radio" class="rad" name="q1" onchange="showAnswers('q1');return false;" />
                <label for="q1_d">Less than 50%
                    <em class="ans q1">INCORRECT!</em> </label> 
            </div>
            <div class="row">
                <input id="q1_e" type="radio" class="rad" name="q1" onchange="showAnswers('q1');return false;" />
                <label for="q1_e">0%
                    <em class="ans q1">INCORRECT!</em> </label> 
            </div>

        </li>
        <li><span class="num">2</span>Is the child having fun/being playful? 

            <div class="row">
                <input id="q2_a" type="radio" class="rad" name="q2" onchange="showAnswers('q2');return false;" />
                <label for="q2_a">100-90%
                    <em class="ans q2">INCORRECT!</em> </label> 
            </div>
            <div class="row">
                <input id="q2_b" type="radio" class="rad" name="q2" onchange="showAnswers('q2');return false;" />
                <label for="q2_b">Greater than 50%
                    <em class="ans q2 correct">CORRECT! (maybe at 90%)</em> </label> 
            </div>
            <div class="row">
                <input id="q2_c" type="radio" class="rad" name="q2" onchange="showAnswers('q2');return false;" />
                <label for="q2_c">50%
                    <em class="ans q2">INCORRECT!</em> </label> 
            </div>
            <div class="row">
                <input id="q2_d" type="radio" class="rad" name="q2" onchange="showAnswers('q2');return false;" />
                <label for="q2_d">Less than 50%
                    <em class="ans q2">INCORRECT!</em> </label> 
            </div>
            <div class="row">
                <input id="q2_e" type="radio" class="rad" name="q2" onchange="showAnswers('q2');return false;" />
                <label for="q2_e">0%
                    <em class="ans q2">INCORRECT!</em> </label> 
            </div>

        </li>
        <li><span class="num">3</span>Is the adult having fun/being playful?   

            <div class="row">
                <input id="q3_a" type="radio" class="rad" name="q3" onchange="showAnswers('q3');return false;" />
                <label for="q3_a">100-90%
                    <em class="ans q3">INCORRECT!</em> </label> 
            </div>
            <div class="row">
                <input id="q3_b" type="radio" class="rad" name="q3" onchange="showAnswers('q3');return false;" />
                <label for="q3_b">Greater than 50%
                    <em class="ans q3 correct">CORRECT! (maybe at 90%)</em> </label>  
            </div>
            <div class="row">
                <input id="q3_c" type="radio" class="rad" name="q3" onchange="showAnswers('q3');return false;" />
                <label for="q3_c">50%
                    <em class="ans q3">INCORRECT!</em> </label> 
            </div>
            <div class="row">
                <input id="q3_d" type="radio" class="rad" name="q3" onchange="showAnswers('q3');return false;" />
                <label for="q3_d">Less than 50%
                    <em class="ans q3">INCORRECT!</em> </label> 
            </div>
            <div class="row">
                <input id="q3_e" type="radio" class="rad" name="q3" onchange="showAnswers('q3');return false;" />
                <label for="q3_e">0%
                    <em class="ans q3">INCORRECT!</em> </label> 
            </div>

        </li>
        <li><span class="num">4</span>Did the child consistently interact and communicate with the adult using gestures and/or words? 

            <div class="row">
                <input id="q4_a" type="radio" class="rad" name="q4" onchange="showAnswers('q4');return false;" />
                <label for="q4_a">100-90%
                    <em class="ans q4">INCORRECT!</em> </label> 
            </div>
            <div class="row">
                <input id="q4_b" type="radio" class="rad" name="q4" onchange="showAnswers('q4');return false;" />
                <label for="q4_b">Greater than 50%
                    <em class="ans q4 correct">CORRECT! (maybe at 90%)</em> </label>  
            </div>
            <div class="row">
                <input id="q4_c" type="radio" class="rad" name="q4" onchange="showAnswers('q4');return false;" />
                <label for="q4_c">50%
                    <em class="ans q4">INCORRECT!</em> </label> 
            </div>
            <div class="row">
                <input id="q4_d" type="radio" class="rad" name="q4" onchange="showAnswers('q4');return false;" />
                <label for="q4_d">Less than 50%
                    <em class="ans q4">INCORRECT!</em> </label> 
            </div>
            <div class="row">
                <input id="q4_e" type="radio" class="rad" name="q4" onchange="showAnswers('q4');return false;" />
                <label for="q4_e">0%
                    <em class="ans q4">INCORRECT!</em> </label> 
            </div>

        </li>
        <li><span class="num">5</span>Did the activity progress in new ways based on the child’s interests?  

            <div class="row">
                <input id="q5_a" type="radio" class="rad" name="q5" onchange="showAnswers('q5');return false;" />
                <label for="q5_a">100-90%
                    <em class="ans q5">INCORRECT!</em> </label> 
            </div>
            <div class="row">
                <input id="q5_b" type="radio" class="rad" name="q5" onchange="showAnswers('q5');return false;" />
                <label for="q5_b">Greater than 50%
                    <em class="ans q5 correct">CORRECT! (maybe at 90%)</em> </label> 
            </div>
            <div class="row">
                <input id="q5_c" type="radio" class="rad" name="q5" onchange="showAnswers('q5');return false;" />
                <label for="q5_c">50%
                    <em class="ans q5">INCORRECT!</em> </label> 
            </div>
            <div class="row">
                <input id="q5_d" type="radio" class="rad" name="q5" onchange="showAnswers('q5');return false;" />
                <label for="q5_d">Less than 50%
                    <em class="ans q5">INCORRECT!</em> </label> 
            </div>
            <div class="row">
                <input id="q5_e" type="radio" class="rad" name="q5" onchange="showAnswers('q5');return false;" />
                <label for="q5_e">0%
                    <em class="ans q5">CORRECT!</em> </label> 
            </div>

        </li>
        <li><span class="num">6</span>If or when the activity didn’t progress, did the child:

            <div class="row">
                <input id="q6_a" type="radio" class="rad" name="q6" onchange="showAnswers('q6');return false;" />
                <label for="q6_a">Stop participating in the activity? - Yes
                    <em class="ans q6">INCORRECT!</em> </label> 
            </div>
            <div class="row">
                <input id="q6_b" type="radio" class="rad" name="q6" onchange="showAnswers('q6');return false;" />
                <label for="q6_b">Stop participating in the activity? - No
                    <em class="ans q6">INCORRECT!</em> </label> 
            </div>
            <div class="row">
                <input id="q6_c" type="radio" class="rad" name="q6" onchange="showAnswers('q6');return false;" />
                <label for="q6_c">Repeat an action? - Yes
                    <em class="ans q6">INCORRECT!</em> </label> 
            </div>
            <div class="row">
                <input id="q6_d" type="radio" class="rad" name="q6" onchange="showAnswers('q6');return false;" />
                <label for="q6_d">Repeat an action? - No
                    <em class="ans q6">INCORRECT!</em> </label> 
            </div>
            <div class="row">
                <input id="q6_e" type="radio" class="rad" name="q6" onchange="showAnswers('q6');return false;" />
                <label for="q6_e">Not Applicable
                    <em class="ans q6 correct">CORRECT!</em> </label> 
            </div>
 

        </li>
        <li><span class="num">7</span>Which of these problems did you see in this sessions?

            <div class="row">
                <input id="q7_a" type="radio" class="rad" name="q7" onchange="showAnswers('q7');return false;" />
                <label for="q7_a"><abbr class="vocab"><abbr class="definitionbox"><abbr class="definition">When a child with autism feels overwhelmed, anxious, or uncomfortable, he or she is likely to avoid interaction by physically walking away or by withdrawing attention.</abbr></abbr><abbr class="term">Avoidance</abbr></abbr>/Distraction
                    <em class="ans q7 correct">CORRECT! (at the beginning of the session)</em> </label> 
            </div>
            <div class="row">
                <input id="q7_b" type="radio" class="rad" name="q7" onchange="showAnswers('q7');return false;" />
                <label for="q7_b">Aggression
                    <em class="ans q7">INCORRECT!</em> </label> 
            </div>
            <div class="row">
                <input id="q7_c" type="radio" class="rad" name="q7" onchange="showAnswers('q7');return false;" />
                <label for="q7_c">Self-Involvement 
                    <em class="ans q7">INCORRECT!</em> </label> 
            </div>
            <div class="row">
                <input id="q7_d" type="radio" class="rad" name="q7" onchange="showAnswers('q7');return false;" />
                <label for="q7_d">Repetitive Activity
                    <em class="ans q7">INCORRECT!</em> </label> 
            </div>
            <div class="row">
                <input id="q7_e" type="radio" class="rad" name="q7" onchange="showAnswers('q7');return false;" />
                <label for="q7_e">Meltdown  
                    <em class="ans q7">INCORRECT!</em> </label> 
            </div>
            <div class="row">
                <input id="q7_f" type="radio" class="rad" name="q7" onchange="showAnswers('q7');return false;" />
                <label for="q7_f">Revving up
                    <em class="ans q7">INCORRECT!</em> </label> 
            </div>
            <div class="row">
                <input id="q7_g" type="radio" class="rad" name="q7" onchange="showAnswers('q7');return false;" />
                <label for="q7_g">Passivity/withdrawn  
                    <em class="ans q7">INCORRECT!</em> </label> 
            </div>
            <div class="row">
                <input id="q7_h" type="radio" class="rad" name="q7" onchange="showAnswers('q7');return false;" />
                <label for="q7_h">Defiance/rigidity  
                    <em class="ans q7">INCORRECT!</em> </label> 
            </div>
            <div class="row">
                <input id="q7_i" type="radio" class="rad" name="q7" onchange="showAnswers('q7');return false;" />
                <label for="q7_i">Aimlessness  
                    <em class="ans q7">INCORRECT!</em> </label> 
            </div>
            <div class="row">
                <input id="q7_j" type="radio" class="rad" name="q7" onchange="showAnswers('q7');return false;" />
                <label for="q7_j">Other  
                    <em class="ans q7">INCORRECT!</em> </label> 
            </div>

        </li>
        <li><span class="num">8</span>Is the adult doing any of these things before or when it happened? <div class="note">Please Note: There are multiple answers for this question, select all that apply.</div>
            
            <a href="#" style="position: absolute; top: 250px; right: 50px;" onclick="showAnswers('q8');return false;" class="btn btn_thin_blue"><span>Check Question 8 Answers</span></a>


            <div class="row">
                <input id="q8_a" type="checkbox" class="rad" name="q8" />
                <label for="q8_a">Not following the Lead
                    <em class="ans q8 correct">CORRECT! (at the beginning of the session)</em> </label> 
            </div>
            <div class="row">
                <input id="q8_b" type="checkbox" class="rad" name="q8" />
                <label for="q8_b">Providing the next step
                    <em class="ans q8 correct">CORRECT! (at the beginning of the session)</em> </label> 
            </div>
            <div class="row">
                <input id="q8_c" type="checkbox" class="rad" name="q8" />
                <label for="q8_c">Too Low <abbr class="vocab"><abbr class="definitionbox"><abbr class="definition">This is the expression of emotion through facial movement, body language, voice tone. These all convey how we feel inside. 'Emotion' is a close but not exact synonym.</abbr></abbr><abbr class="term">Affect</abbr></abbr> 
                    <em class="ans q8 correct">CORRECT! (at the beginning of the session)</em> </label> 
            </div>
            <div class="row">
                <input id="q8_d" type="checkbox" class="rad" name="q8" />
                <label for="q8_d">Over Stimulating
                    <em class="ans q8">INCORRECT!</em> </label> 
            </div>
            <div class="row">
                <input id="q8_e" type="checkbox" class="rad" name="q8" />
                <label for="q8_e">Too Challenging
                    <em class="ans q8 correct">CORRECT! (when hiding the glasses case)</em> </label> 
            </div>
            <div class="row">
                <input id="q8_f" type="checkbox" class="rad" name="q8" />
                <label for="q8_f">Not Challenging Enough
                    <em class="ans q8">INCORRECT!</em> </label> 
            </div>
            <div class="row">
                <input id="q8_g" type="checkbox" class="rad" name="q8" />
                <label for="q8_g">Not Responding to Subtle Gesture
                    <em class="ans q8">INCORRECT!</em> </label> 
            </div>
            <div class="row">
                <input id="q8_h" type="checkbox" class="rad" name="q8" />
                <label for="q8_h">Too Little Sensory Input
                    <em class="ans q8">INCORRECT!</em> </label> 
            </div>
            <div class="row">
                <input id="q8_i" type="checkbox" class="rad" name="q8" />
                <label for="q8_i">Too Much Sensory Input
                    <em class="ans q8">INCORRECT!</em> </label> 
            </div>

        </li>
    </ol>
    <p class="last">For descriptions of and suggestions for these 8 problems, please go to the Home page and click on ‘Troubleshooting Floortime’ in the navigation bar.  </p>

    <a href="#" onclick="HideEvaluation();return false;" class="btn btn_thin_blue"><span>I'm finished with the evaluation</span></a>
    <a href="#" onclick="HideEvaluation();return false;" class="btn btn_cancel">[x] cancel</a>


</div>