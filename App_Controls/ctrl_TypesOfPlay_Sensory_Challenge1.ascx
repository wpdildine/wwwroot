<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ctrl_TypesOfPlay_Sensory_Challenge1.ascx.cs" Inherits="App_Controls_ctrl_TypesOfPlay_Sensory_Challenge1" %>
<%@ Register src="ctrl__Overlay_SensoryChallenge1.ascx" tagname="ctrl__Overlay_SensoryChallenge" tagprefix="uc1" %>

<uc1:ctrl__Overlay_SensoryChallenge ID="ctrl__Overlay_SensoryChallenge1" runat="server" />

<div id="content">
    <h1><label>Sensory:</label> Challenge Example 1</h1>
    <h2 class="h2_gray2">Challenging a child to engage and communicate during sensory play</h2>
    <h2 class="h2_gray">"Boy running with blanket"</h2>
                    
    <div class="section sect_on" id="section1">

        <div class="num">1
        </div>
        <div class="instructions">Please complete the previous step before continuing</div>
        <div class="cont">

            <a href="#" onclick="toggleMedia('1');return false;" class="mediabtn mediabtn_long">Play Video #1
                <img src="/App_Images/ico_video_med_gold.png" alt="Play Video" />
                <span class="long">Please watch this video to see a successful example of ‘Challenging” and review the bullet points below it</span>
            </a>
            <div class="media_holder open" id="mholder_1">
                <iframe src="https://player.vimeo.com/video/125620552" width="948" height="711" frameborder="0" webkitallowfullscreen mozallowfullscreen allowfullscreen></iframe>
            </div>
<%--            <div class="btn_holder" style="margin-left: 50px;">
                <label>Please revisit the Challenge General Techniques PDF when watching the above video:</label>
                <a target="_blank" href="/App_PDF/Greenspan_GeneralTechniquesPDF_Challenge.pdf" class="btn btn_thin_red"><span>Download PDF</span></a>
            </div>--%>

        </div>

    </div>

    <div class="section sect_on" id="section2">

        <div class="num">2</div>
        <div class="instructions">Please complete the previous step before continuing</div>
        <div class="cont">

            <span class="inst">Specific ‘Challenge’ techniques shown in the video</span>

            <ul class="star_blue_med">

                <li>Mom has fun playing and is enthusiastic.</li>
                <li>Mom <abbr class="vocab"><abbr class="definitionbox"><abbr class="definition">An important element of Floortime involves “challenging” the child by playfully changing or obstructing play. The purpose of challenging is to elicit a direct response – thus “closing a circle of communication.”</abbr></abbr><abbr class="term">challenge</abbr></abbr>s Stephen by blocking him (<abbr class="vocab"><abbr class="definitionbox"><abbr class="definition">Children with autism often engage in repetitive behaviors. Rather than attempting to stop the behaviors, a Floortime therapist or parent may choose to engage with the behavior by playfully obstructing it – thus encouraging the child to respond and thereby close a circle of communication. For example, a child running a car back and forth on a table may respond with a sound, motion, or words when a parent creates a “roadblock” to navigate.</abbr></abbr><abbr class="term">playful obstruction</abbr></abbr>).</li>
                <li>Mom entices him as she keeps up a dialogue about what she is doing.</li>
                <li>Mom chooses a <abbr class="vocab"><abbr class="definitionbox"><abbr class="definition">An important element of Floortime involves “challenging” the child by playfully changing or obstructing play. The purpose of challenging is to elicit a direct response – thus “closing a circle of communication.”</abbr></abbr><abbr class="term">challenge</abbr></abbr> that Stephen can overcome successfully.</li>
                <li>Mom moves slowly to let Stephen be fully involved.</li>
                <li>Mom <abbr class="vocab"><abbr class="definitionbox"><abbr class="definition">An important element of Floortime involves “challenging” the child by playfully changing or obstructing play. The purpose of challenging is to elicit a direct response – thus “closing a circle of communication.”</abbr></abbr><abbr class="term">challenge</abbr></abbr>s him to respond physically not verbally because that is what he is capable of in that session.</li>
                <li>Mom’s <abbr class="vocab"><abbr class="definitionbox"><abbr class="definition">An important element of Floortime involves “challenging” the child by playfully changing or obstructing play. The purpose of challenging is to elicit a direct response – thus “closing a circle of communication.”</abbr></abbr><abbr class="term">challenge</abbr></abbr> gets him to respond physically, allowing Stephen to close circles of communication and experience a back-and-forth response rhythm. </li>

            </ul>

        </div>

    </div>

    <div class="section sect_on" id="section3">

        <div class="num">3</div>
        <div class="instructions">Please complete the previous step before continuing</div>
        <div class="cont">

            <a href="#" onclick="turnOnSection('4');turnOnSection('5');turnOnSection('6');toggleMedia('2');return false;"class="mediabtn mediabtn_long">Play Audio #1
                <img src="/App_Images/ico_audio_med_blue.png" alt="Play Audio" />
                <span>Now listen to a summary of the principles used in the video</span>
            </a>
            <div class="media_holder audio_holder" id="mholder_2">
                
                <div id="player-stephen"></div>
<script type="text/javascript">// <![CDATA[
    var _0xdb51 = ["\x68\x74\x74\x70\x73\x3A\x2F\x2F\x73\x33\x2E\x61\x6D\x61\x7A\x6F\x6E\x61\x77\x73\x2E\x63\x6F\x6D\x2F\x73\x74\x61\x6E\x6C\x65\x79\x67\x72\x65\x65\x6E\x73\x70\x61\x6E\x2F\x42\x61\x6C\x61\x6E\x63\x65\x2F\x73\x74\x65\x70\x68\x65\x6E\x2D\x62\x6C\x61\x6E\x6B\x65\x74\x2D\x63\x68\x61\x6C\x6C\x65\x6E\x67\x65\x2E\x6D\x70\x33", "\x2F\x2F\x77\x77\x77\x2E\x73\x74\x61\x6E\x6C\x65\x79\x67\x72\x65\x65\x6E\x73\x70\x61\x6E\x2E\x63\x6F\x6D\x2F\x70\x6F\x72\x74\x61\x6C\x2F\x73\x69\x74\x65\x73\x2F\x64\x65\x66\x61\x75\x6C\x74\x2F\x66\x69\x6C\x65\x73\x2F\x53\x74\x61\x6E\x6C\x65\x79\x47\x72\x65\x65\x6E\x73\x70\x61\x6E\x2D\x31\x35\x30\x78\x31\x35\x30\x31\x2E\x6A\x70\x67", "\x73\x65\x74\x75\x70", "\x70\x6C\x61\x79\x65\x72\x2D\x73\x74\x65\x70\x68\x65\x6E"]; jwplayer(_0xdb51[3])[_0xdb51[2]]({ file: _0xdb51[0], image: _0xdb51[1], controls: true, width: 948, height: 25 });
    // ]]></script>
            </div>

        </div>

    </div>

    <h3 class="expand">Expanding The Challenge</h3>


    <div class="section" id="section4">

        <div class="num">4</div>
        <div class="instructions">Please complete the previous step before continuing</div>
        <div class="cont">

            <a href="#" onclick="turnOnSection('5');toggleMedia('3');return false;"class="mediabtn mediabtn_long">Play Video #2
                <img src="/App_Images/ico_video_med_gold.png" alt="Play Video" />
                <span class="long">Please play the video to see how the parent expands the play and review the bullet points below it</span>
            </a>
            <div class="media_holder" id="mholder_3">
                <iframe src="https://player.vimeo.com/video/125603656" width="948" height="711" frameborder="0" webkitallowfullscreen mozallowfullscreen allowfullscreen></iframe>
            </div>

        </div>

    </div>

    <div class="section" id="section5">

        <div class="num">5</div>
        <div class="instructions">Please complete the previous step before continuing</div>
        <div class="cont">

            <span class="inst">Specific ‘Expand’ techniques shown in the video</span>
            <ul class="star_blue_med">

                <li>Mom <abbr class="vocab"><abbr class="definitionbox"><abbr class="definition">This Floortime step involves the adult subtly increasing or changing the challenges in the activity or play. It encourages the child to explore novel movements, activities, ideas, or modes of communication. </abbr></abbr><abbr class="term">expand</abbr></abbr>s incrementally. </li>
                <li>1st - Mom <abbr class="vocab"><abbr class="definitionbox"><abbr class="definition">This Floortime step involves the adult subtly increasing or changing the challenges in the activity or play. It encourages the child to explore novel movements, activities, ideas, or modes of communication. </abbr></abbr><abbr class="term">expand</abbr></abbr>s first from the human fence to going after Stephen’s blanket, a sensory object that he is interested in.</li>
                <li>2nd - Mom makes the next expansion - Stephen getting back the blanket - something that he can do successfully.</li>
                <li>Mom goes slowly. </li>
                <li>3rd - Mom lets Stephen partially succeed in getting the blanket.</li>
                <li>4th - Mom <abbr class="vocab"><abbr class="definitionbox"><abbr class="definition">This Floortime step involves the adult subtly increasing or changing the challenges in the activity or play. It encourages the child to explore novel movements, activities, ideas, or modes of communication. </abbr></abbr><abbr class="term">expand</abbr></abbr>s by not immediately letting go and causing Stephen take one more step to succeed in getting the blanket.</li>

            </ul>

        </div>

    </div>

    <div class="section" id="section6">

        <div class="num">6</div>
        <div class="instructions">Please complete the previous step before continuing</div>
        <div class="cont">

            <div class="btn_holder">
                <label>Now review the <a target="_blank" style="color: #134674" href="/App_PDF/Greenspan_GeneralTechniquesPDF_Expand.pdf">general techniques</a> for "Expand" (print out) to think through what else Mom/Dad could do to expand</label>
                <a href="#" onclick="turnOnSection('7');DoEvaluation();return false;" class="btn btn_thin_red"><span>Do The Interactive Evaluation</span></a>

            </div>

        </div>

    </div>

    <div class="section" id="section7">

        <div class="num">7</div>
        <div class="instructions">Please complete the previous step before continuing</div>
        <div class="cont">

            <div class="btn_holder">
                <label>Once you have finished the interactive evaluation, move on:</label>
                <a href="challenge2.aspx" class="btn btn_thin_blue"><span>Challenge & Expand Example 2</span></a>

            </div>

        </div>

    </div>
</div>