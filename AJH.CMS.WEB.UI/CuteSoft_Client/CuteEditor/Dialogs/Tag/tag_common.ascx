<%@ Control Inherits="CuteEditor.EditorUtilityCtrl" Language="c#" AutoEventWireup="false" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<fieldset style="padding:4px;width:430px">
	<legend>[[Attributes]]</legend>
	<div align="left">
		<table class="normal" width="98%">
			<tr>		
				<td>[[CssClass]]:</td>
				<td><input type="text" id="inp_class" style="width:130px" /></td>	
			</tr>
			<tr>
			<td>[[Width]] :</td>
				<td><input type="text" id="inp_width" style="width:130px" onkeypress="return CancelEventIfNotDigit()" /></td>
				
			</tr>
			<tr>
				<td>[[Height]] :</td>
				<td><input type="text" id="inp_height" style="width:130px" onkeypress="return CancelEventIfNotDigit()" /></td>
			</tr>
			<tr>		
				<td>[[Alignment]]:</td>
				<td><select id="sel_align" style="width:130px" >
						<option value="">[[NotSet]]</option>
						<option value="left">[[Left]]</option>
						<option value="center">[[Center]]</option>
						<option value="right">[[Right]]</option>
					</select>
				</td>
			</tr>
			<tr>		
				<td>[[Text-Align]]:</td>
				<td><select id="sel_textalign" style="width:130px" >
						<option value="">[[NotSet]]</option>
						<option value="left">[[Left]]</option>
						<option value="center">[[Center]]</option>
						<option value="right">[[Right]]</option>
						<option value="justify">[[Justify]]</option>
					</select>
				</td>
			</tr>
			<tr>		
				<td>[[Float]]:</td>
				<td><select id="sel_float" style="width:130px" >
						<option value="">[[NotSet]]</option>
						<option value="left">[[Left]]</option>
						<option value="right">[[Right]]</option>
					</select>
				</td>
			</tr>
			<tr>
				<td>[[Color]]</td>
				<td>
<input autocomplete="off" type="text" id="inp_forecolor" name="inp_forecolor" size="7" style="WIDTH:72px" />
<img alt="" id="img_forecolor" src="Load.ashx?type=image&file=colorpicker.gif" style="margin-bottom:-2px" />
				</td>
			</tr>
			<tr>
				<td>[[BackColor]]</td>
				<td>
<input autocomplete="off" type="text" id="inp_backcolor" name="inp_backcolor" size="7" style="WIDTH:72px" />
<img alt="" id="img_backcolor" src="Load.ashx?type=image&file=colorpicker.gif" style="margin-bottom:-2px" />
				</td>
			</tr>
			<tr>		
				<td style='width:100px'>[[Title]]:</td>
				<td>
					<textarea id="inp_tooltip" rows="5" cols="20" style="width:220px"></textarea>
				</td>
			</tr>
		</table>
	</div>
</fieldset>
<script type="text/javascript" src="Load.ashx?type=dialogscript&verfix=1006&file=Dialog_Tag_Common.js"></script>

