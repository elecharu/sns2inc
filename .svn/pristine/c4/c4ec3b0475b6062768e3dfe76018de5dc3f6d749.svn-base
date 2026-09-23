<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ItsCombo.ascx.cs" Inherits="ItsCombo" %>
    <!-- Combo -->
    <div class="ItsCombo"<% if (_ReadOnly == "true") { %> readonly="readonly"<% } %>
        style="float:<%= _Float %>;<% if (_Hidden == "true") { %>display:none;<% } %>">
        <div class="ItsCombo_table">
            <span style="width:<%= _LabelWidth %>px;<% if (_Required) { %>color:red;<% } %>"><%= _Label %></span>
            <div class="ItsCombo_box">
                <input type="text" <% if (_ID != "") { %>id="<%= _ID %>"<% } %> 
                    style="width:<%= _InputWidth %>px;<% if (_ReadOnly == "true") { %> background-color:aliceblue;<% } %>" class="ItsField ItsCombo"
                    data-field="<%= _Field %>" data-value="<%= _Value %>" 
                    data-default="<%= _Value %>" data-gpcd="<%= _GPCD %>"
                    data-ref01="<%= _REF01 %>" data-ref02="<%= _REF02 %>"
                    data-ref03="<%= _REF03 %>" data-ref04="<%= _REF04 %>"
                    data-ref05="<%= _REF05 %>" data-ref06="<%= _REF06 %>"
                    data-ref07="<%= _REF07 %>" data-ref08="<%= _REF08 %>"
                    data-ref09="<%= _REF09 %>" data-ref10="<%= _REF10 %>"
                    autocomplete="off"
                    value="" readonly="readonly" />
                <div class="ItsCombo_button"><i class="fa fa-sort-desc"></i></div>
                <ul class="ItsControl_pop" style="min-width:<%= (_InputWidth + 36) %>px">
                   <%= _TAG %>
                </ul>
            </div>
        </div>
    </div>