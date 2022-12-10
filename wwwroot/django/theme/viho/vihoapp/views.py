from django.http import request
from django.shortcuts import render
from django.http import HttpResponse,JsonResponse
from django.http import HttpResponseRedirect
from django.http.response import HttpResponseRedirect
from django.shortcuts import redirect, render
from django.http import HttpResponse
from .models import *
from .forms import *
from .models import User
from django.contrib.auth.forms import UserCreationForm, AuthenticationForm
from django.contrib.auth import login, logout
from django.contrib.auth.decorators import login_required

# Create your views here.

#main index file-------->

@login_required(login_url="/login")
def defaultPage(request):
    return redirect('/default')

@login_required(login_url="/login")
def default(request):
    return render(request,'index.html')
    
@login_required(login_url="/login")
def ecommerce(request):
    return render(request,'general/dashboards/ecommerce/index.html')

@login_required(login_url="/login")
def general(request):
    context = {"breadcrumb":{"parent":"Widgets", "child":"General"}}
    return render(request,'general/widgets/general/general.html', context)

@login_required(login_url="/login")
def charts(request):
    context = {"breadcrumb":{"parent":"Widgets", "child":"Charts"}}
    return render(request,'general/widgets/charts/charts.html', context)

@login_required(login_url="/login")
def box(request):
    context = {"layout": "box-layout","breadcrumb":{"parent":"Page Layout", "child":"Box Layout"}}
    return render(request,'general/page-layouts/box-layout.html', context)

@login_required(login_url="/login")
def rtl(request):
    context = {"layout": "rtl", "breadcrumb":{"parent":"Page Layout", "child":"RTL Layout"}}
    return render(request,'general/page-layouts/rtl-layout.html', context)

@login_required(login_url="/login")
def dark(request):
    context = {"layout": "dark-only", "breadcrumb":{"parent":"Page layout", "child":"Layout Dark"}}
    return render(request,'general/page-layouts/dark-layout.html', context)

@login_required(login_url="/login")
def footerfix(request):
    context = {"footer": "footer-fix", "breadcrumb":{"parent":"footer", "child":"footer fixed"}}
    return render(request,'general/page-layouts/footer-fix.html', context)

@login_required(login_url="/login")
def footerdark(request):
    context = {"footer": "footer-dark", "breadcrumb":{"parent":"footer", "child":"footer dark"}}
    return render(request,'general/page-layouts/footer-dark.html', context)

@login_required(login_url="/login")
def footerlight(request):
    context = {"footer": "", "breadcrumb":{"parent":"footer", "child":"footer light"}}
    return render(request,'general/page-layouts/footer-light.html', context)

@login_required(login_url="/login")
def statecolor(request):
    context = {"breadcrumb":{"parent":"Ui kits", "child":"State Color"}}
    return render(request,'components/ui-kits/state-color.html', context)        

@login_required(login_url="/login")
def typography(request):
    context = {"breadcrumb":{"parent":"Ui kits", "child":"Typography"}}
    return render(request,'components/ui-kits/typography.html', context)        

@login_required(login_url="/login")
def avatars(request):
    context = {"breadcrumb":{"parent":"Ui kits", "child":"Avatars"}}
    return render(request,'components/ui-kits/avatars.html', context)        

@login_required(login_url="/login")
def helper(request):
    context = {"breadcrumb":{"parent":"Ui kits", "child":"Helper Classes"}}
    return render(request,'components/ui-kits/helper.html', context)        

@login_required(login_url="/login")
def grid_simple(request):
    context = {"breadcrumb":{"parent":"Ui kits", "child":"grid"}}
    return render(request,'components/ui-kits/grid.html', context)        

@login_required(login_url="/login")
def tagpills(request):
    context = {"breadcrumb":{"parent":"Ui kits", "child":"Tag & Pills"}}
    return render(request,'components/ui-kits/tag-pills.html', context)        

@login_required(login_url="/login")
def progressbar(request):
    context = {"breadcrumb":{"parent":"Ui kits", "child":"Progress"}}
    return render(request,'components/ui-kits/progressbar.html', context)        

@login_required(login_url="/login")
def modal(request):
    context = {"breadcrumb":{"parent":"Ui kits", "child":"modal"}}
    return render(request,'components/ui-kits/modal.html', context)        

@login_required(login_url="/login")
def alert(request):
    context = {"breadcrumb":{"parent":"Ui kits", "child":"alert"}}
    return render(request,'components/ui-kits/alert.html', context)        

@login_required(login_url="/login")
def popover(request):
    context = {"breadcrumb":{"parent":"Ui kits", "child":"popover"}}
    return render(request,'components/ui-kits/popover.html', context)        

@login_required(login_url="/login")
def tooltip(request):
    context = {"breadcrumb":{"parent":"Ui kits", "child":"tooltip"}}
    return render(request,'components/ui-kits/tooltip.html', context)                                                                               

@login_required(login_url="/login")
def spiners(request):
    context = {"breadcrumb":{"parent":"Ui kits", "child":"spiners"}}
    return render(request,'components/ui-kits/spiners.html', context)        

@login_required(login_url="/login")
def dropdown(request):
    context = {"breadcrumb":{"parent":"Ui kits", "child":"dropdown"}}
    return render(request,'components/ui-kits/dropdown.html', context)        

@login_required(login_url="/login")
def accordion(request):
    context = {"breadcrumb":{"parent":"Ui kits", "child":"accordion"}}
    return render(request,'components/ui-kits/accordion.html', context)        

@login_required(login_url="/login")
def bootstraptab(request):
    context = {"breadcrumb":{"parent":"Ui kits", "child":"Bootstrap Tabs"}}
    return render(request,'components/ui-kits/bootstraptab.html', context)        

@login_required(login_url="/login")
def linetab(request):
    context = {"breadcrumb":{"parent":"Ui kits", "child":"Line Tabs"}}
    return render(request,'components/ui-kits/linetab.html', context)        

@login_required(login_url="/login")
def navs(request):
    context = {"breadcrumb":{"parent":"Ui kits", "child":"navs"}}
    return render(request,'components/ui-kits/navs.html', context)        

@login_required(login_url="/login")
def shadow(request):
    context = {"breadcrumb":{"parent":"Ui kits", "child":"Box Shadow"}}
    return render(request,'components/ui-kits/shadow.html', context)        

@login_required(login_url="/login")
def lists(request):
    context = {"breadcrumb":{"parent":"Ui kits", "child":"Lists"}}
    return render(request,'components/ui-kits/lists.html', context)        

@login_required(login_url="/login")
def scrollable(request):
    context = {"breadcrumb":{"parent":"Bonus Ui", "child":"Scrollable"}}
    return render(request,'components/bonus-ui/scrollable.html', context)        

@login_required(login_url="/login")
def tree(request):
    context = {"breadcrumb":{"parent":"Bonus Ui", "child":"Tree View"}}
    return render(request,'components/bonus-ui/tree.html', context)        

@login_required(login_url="/login")
def bootstrapnotify(request):
    context = {"breadcrumb":{"parent":"Bonus Ui", "child":"Bootstrap Notify"}}
    return render(request,'components/bonus-ui/bootstrapnotify.html', context)        

@login_required(login_url="/login")
def rating(request):
    context = {"breadcrumb":{"parent":"Bonus Ui", "child":"rating"}}
    return render(request,'components/bonus-ui/rating.html', context)        

@login_required(login_url="/login")
def dropzone(request):
    context = {"breadcrumb":{"parent":"Bonus Ui", "child":"dropzone"}}
    return render(request,'components/bonus-ui/dropzone.html', context)        

@login_required(login_url="/login")
def tour(request):
    context = {"breadcrumb":{"parent":"Bonus Ui", "child":"tour"}}
    return render(request,'components/bonus-ui/tour.html', context)        

@login_required(login_url="/login")
def sweetalert(request):
    context = {"breadcrumb":{"parent":"Bonus Ui", "child":"Sweet Alert"}}
    return render(request,'components/bonus-ui/sweetalert.html', context)        

@login_required(login_url="/login")
def animatedmodal(request):
    context = {"breadcrumb":{"parent":"Bonus Ui", "child":"Animated Modal"}}
    return render(request,'components/bonus-ui/animatedmodal.html', context)        

@login_required(login_url="/login")
def owlcarousel(request):
    context = {"breadcrumb":{"parent":"Bonus Ui", "child":"Owl Carousel"}}
    return render(request,'components/bonus-ui/owlcarousel.html', context)        

@login_required(login_url="/login")
def ribbons(request):
    context = {"breadcrumb":{"parent":"Bonus Ui", "child":"Ribbons"}}
    return render(request,'components/bonus-ui/ribbons.html', context)        

@login_required(login_url="/login")
def pagination(request):
    context = {"breadcrumb":{"parent":"Bonus Ui", "child":"Pagination"}}
    return render(request,'components/bonus-ui/pagination.html', context)        

@login_required(login_url="/login")
def steps(request):
    context = {"breadcrumb":{"parent":"Bonus Ui", "child":"Steps"}}
    return render(request,'components/bonus-ui/steps.html', context)        

@login_required(login_url="/login")
def breadcrumb(request):
    context = {"breadcrumb":{"parent":"Bonus Ui", "child":"Breadcrumb"}}
    return render(request,'components/bonus-ui/breadcrumb.html', context)        

@login_required(login_url="/login")
def rangeslider(request):
    context = {"breadcrumb":{"parent":"Bonus Ui", "child":"Range Slider  "}}
    return render(request,'components/bonus-ui/rangeslider.html', context)        

@login_required(login_url="/login")
def imagecropper(request):
    context = {"breadcrumb":{"parent":"Bonus Ui", "child":"Image Cropper"}}
    return render(request,'components/bonus-ui/imagecropper.html', context)        

@login_required(login_url="/login")
def sticky(request):
    context = {"breadcrumb":{"parent":"Bonus Ui", "child":"Sticky"}}
    return render(request,'components/bonus-ui/sticky.html', context)        

@login_required(login_url="/login")
def basiccard(request):
    context = {"breadcrumb":{"parent":"Bonus Ui", "child":"Basic Card"}}
    return render(request,'components/bonus-ui/basiccard.html', context)        

@login_required(login_url="/login")
def creativecard(request):
    context = {"breadcrumb":{"parent":"Bonus Ui", "child":"Creative Card"}}
    return render(request,'components/bonus-ui/creativecard.html', context)        

@login_required(login_url="/login")
def tabbedcard(request):
    context = {"breadcrumb":{"parent":"Bonus Ui", "child":"Tabbed Card"}}
    return render(request,'components/bonus-ui/tabbedcard.html', context)        

@login_required(login_url="/login")
def draggablecard(request):
    context = {"breadcrumb":{"parent":"Bonus Ui", "child":"Draggable Card"}}
    return render(request,'components/bonus-ui/draggablecard.html', context)        

@login_required(login_url="/login")
def timeline1(request):
    context = {"breadcrumb":{"parent":"Bonus Ui", "child":"Timeline 1"}}
    return render(request,'components/bonus-ui/timeline1.html', context)        

@login_required(login_url="/login")
def timeline2(request):
    context = {"breadcrumb":{"parent":"Bonus Ui", "child":"Timeline 2"}}
    return render(request,'components/bonus-ui/timeline2.html', context)        

@login_required(login_url="/login")
def formbuilder1(request):
    context = {"breadcrumb":{"parent":"Builders", "child":"Form Builder 1"}}
    return render(request,'components/builders/formbuilder1.html', context)        

@login_required(login_url="/login")
def formbuilder2(request):
    context = {"breadcrumb":{"parent":"Builders", "child":"Form Builder 2"}}
    return render(request,'components/builders/formbuilder2.html', context)        

@login_required(login_url="/login")
def pagebuild(request):
    context = {"breadcrumb":{"parent":"Builders", "child":"Page Builder"}}
    return render(request,'components/builders/pagebuild.html', context)        

@login_required(login_url="/login")
def buttonbuilder(request):
    context = {"layout": "button-builder", "breadcrumb":{"parent":"Builders", "child":"Button Builder"}}
    return render(request,'components/builders/buttonbuilder.html', context)        

@login_required(login_url="/login")
def animate(request):
    context = {"breadcrumb":{"parent":"Animation", "child":"Animate"}}
    return render(request,'components/animation/animate.html', context)        

@login_required(login_url="/login")
def scrollreval(request):
    context = {"breadcrumb":{"parent":"Animation", "child":"scrollreval"}}
    return render(request,'components/animation/scrollreval.html', context)        

@login_required(login_url="/login")
def AOS(request):
    context = {"breadcrumb":{"parent":"Animation", "child":"AOS"}}
    return render(request,'components/animation/AOS.html', context)        

@login_required(login_url="/login")
def tilt(request):
    context = {"breadcrumb":{"parent":"Animation", "child":"tilt"}}
    return render(request,'components/animation/tilt.html', context)        

@login_required(login_url="/login")
def wow(request):
    context = {"breadcrumb":{"parent":"Animation", "child":"wow"}}
    return render(request,'components/animation/wow.html', context)        
 
@login_required(login_url="/login")
def flagicon(request):
    context = {"breadcrumb":{"parent":"Icons", "child":"Flag Icons"}}
    return render(request,'components/icons/flagicon.html', context)        

@login_required(login_url="/login")
def fontawesome(request):
    context = {"breadcrumb":{"parent":"Icons", "child":"Font Awesome Icon"}}
    return render(request,'components/icons/fontawesome.html', context)        

@login_required(login_url="/login")
def icoicon(request):
    context = {"breadcrumb":{"parent":"Icons", "child":"Ico Icon"}}
    return render(request,'components/icons/icoicon.html', context)        

@login_required(login_url="/login")
def themify(request):
    context = {"breadcrumb":{"parent":"Icons", "child":"Themify Icon"}}
    return render(request,'components/icons/themify.html', context)        

@login_required(login_url="/login")
def feather(request):
    context = {"breadcrumb":{"parent":"Icons", "child":"Feather Icons"}}
    return render(request,'components/icons/feather.html', context)        

@login_required(login_url="/login")
def whether(request):
    context = {"breadcrumb":{"parent":"Icons", "child":"Whether Icon"}}
    return render(request,'components/icons/whether.html', context)        

@login_required(login_url="/login")
def buttons(request):
    context = {"breadcrumb":{"parent":"Buttons", "child":"buttons"}}
    return render(request,'components/buttons/buttons.html', context)        

@login_required(login_url="/login")
def flat(request):
    context = {"breadcrumb":{"parent":"Buttons", "child":"flat"}}
    return render(request,'components/buttons/flat.html', context)        

@login_required(login_url="/login")
def edge(request):
    context = {"breadcrumb":{"parent":"Buttons", "child":"edge"}}
    return render(request,'components/buttons/edge.html', context)        

@login_required(login_url="/login")
def raised(request):
    context = {"breadcrumb":{"parent":"Buttons", "child":"raised"}}
    return render(request,'components/buttons/raised.html', context)        

@login_required(login_url="/login")
def group(request):
    context = {"breadcrumb":{"parent":"Buttons", "child":"group"}}
    return render(request,'components/buttons/btn-group.html', context)        

@login_required(login_url="/login")
def apex(request):
    context = {"breadcrumb":{"parent":"charts", "child":"apex"}}
    return render(request,'components/charts/apex.html', context)        

@login_required(login_url="/login")
def chartjs(request):
    context = {"breadcrumb":{"parent":"charts", "child":"chartjs"}}
    return render(request,'components/charts/chartjs.html', context)        

@login_required(login_url="/login")
def chartist(request):
    context = {"breadcrumb":{"parent":"charts", "child":"chartist"}}
    return render(request,'components/charts/chartist.html', context)        

@login_required(login_url="/login")
def flot(request):
    context = {"breadcrumb":{"parent":"charts", "child":"flot"}}
    return render(request,'components/charts/flot.html', context)        

@login_required(login_url="/login")
def google(request):
    context = {"breadcrumb":{"parent":"charts", "child":"google"}}
    return render(request,'components/charts/google.html', context)        

@login_required(login_url="/login")
def knob(request):
    context = {"breadcrumb":{"parent":"charts", "child":"knob"}}
    return render(request,'components/charts/knob.html', context)        

@login_required(login_url="/login")
def morris(request):
    context = {"breadcrumb":{"parent":"charts", "child":"morris"}}
    return render(request,'components/charts/morris.html', context)        

@login_required(login_url="/login")
def peity(request):
    context = {"breadcrumb":{"parent":"charts", "child":"peity"}}
    return render(request,'components/charts/peity.html', context)        

@login_required(login_url="/login")
def sparkline(request):
    context = {"breadcrumb":{"parent":"charts", "child":"sparkline"}}
    return render(request,'components/charts/sparkline.html', context)        

#--------------------------------Forms & Table-----------------------------------------------
#--------------------------------Forms------------------------------------
#------------------------form-controls

@login_required(login_url="/login")
def form_validation(request):
    context = {"breadcrumb":{"parent":"Form Controls", "child":"Validation Forms"}}
    return render(request,'forms/form-controls/form-validation/form-validation.html',context)


@login_required(login_url="/login")
def base_input(request):
    context = {"breadcrumb":{"parent":"Form Controls", "child":"Base Inputs"}}
    return render(request,'forms/form-controls/base-input/base-input.html',context) 


@login_required(login_url="/login")
def radio_checkbox_control(request):
    context = {"breadcrumb":{"parent":"Form Controls", "child":"Checkbox & Radio"}}
    return render(request,'forms/form-controls/radio-checkbox-control/radio-checkbox-control.html',context)


@login_required(login_url="/login")
def input_group(request):
    context = {"breadcrumb":{"parent":"Form Controls", "child":"Input Groups"}}
    return render(request,'forms/form-controls/input-group/input-group.html',context) 


@login_required(login_url="/login")
def megaoptions(request):
    context = {"breadcrumb":{"parent":"Form Controls", "child":"Mega Options"}}
    return render(request,'forms/form-controls/megaoptions/megaoptions.html',context) 

#---------------------------form widgets


@login_required(login_url="/login")
def datepicker(request):
    context = {"breadcrumb":{"parent":"Form Widgets", "child":"Date Picker"}}
    return render(request,'forms/form-widgets/datepicker/datepicker.html',context) 


@login_required(login_url="/login")
def time_picker(request):
    context = {"breadcrumb":{"parent":"Form Widgets", "child":"Time Picker"}}
    return render(request,'forms/form-widgets/time-picker/time-picker.html',context) 


@login_required(login_url="/login")
def datetimepicker(request):
    context = {"breadcrumb":{"parent":"Form Widgets", "child":"Date Time Picker"}}
    return render(request,'forms/form-widgets/datetimepicker/datetimepicker.html',context) 
    

@login_required(login_url="/login")
def daterangepicker(request):
    context = {"breadcrumb":{"parent":"Form Widgets", "child":"Date Range Picker"}}
    return render(request,'forms/form-widgets/daterangepicker/daterangepicker.html',context) 


@login_required(login_url="/login")
def touchspin(request):
    context = {"breadcrumb":{"parent":"Form Widgets", "child":"Touchspin"}}
    return render(request,'forms/form-widgets/touchspin/touchspin.html',context) 


@login_required(login_url="/login")
def select2(request):
    context = {"breadcrumb":{"parent":"Form Widgets", "child":"Select2"}}
    return render(request,'forms/form-widgets/select2/select2.html',context) 


@login_required(login_url="/login")
def switch(request):
    context = {"breadcrumb":{"parent":"Form Widgets", "child":"Switch"}}
    return render(request,'forms/form-widgets/switch/switch.html',context) 
    

@login_required(login_url="/login")
def typeahead(request):
    context = {"breadcrumb":{"parent":"Form Widgets", "child":"Typeahead"}}
    return render(request,'forms/form-widgets/typeahead/typeahead.html',context) 
    

@login_required(login_url="/login")
def clipboard(request):
    context = {"breadcrumb":{"parent":"Form Widgets", "child":"Clipboard"}}
    return render(request,'forms/form-widgets/clipboard/clipboard.html',context)

#-----------------------form layout

@login_required(login_url="/login")
def default_form(request):
    context = {"breadcrumb":{"parent":"Form Layout", "child":"Default Forms"}}
    return render(request,'forms/form-layout/default-form/default-form.html',context)


@login_required(login_url="/login")
def form_wizards(request):
    context = {"breadcrumb":{"parent":"Form Layout", "child":"Form Wizard"}}
    return render(request,'forms/form-layout/form-wizard/form-wizard.html',context) 


@login_required(login_url="/login")
def form_wizard_two(request):
    context = {"breadcrumb":{"parent":"Form Layout", "child":"Step Form Wizard"}}
    return render(request,'forms/form-layout/form-wizard-two/form-wizard-two.html',context) 


@login_required(login_url="/login")
def form_wizard_three(request):
    context = {"breadcrumb":{"parent":"Form Layout", "child":"Form Wizard With Icon"}}
    return render(request,'forms/form-layout/form-wizard-three/form-wizard-three.html',context)


#----------------------------------------------------Table------------------------------------------
#------------------------bootstrap table

@login_required(login_url="/login")
def basic_table(request):
    context = {"breadcrumb":{"parent":"Bootstrap Tables", "child":"Bootstrap Basic Tables"}}
    return render(request,'table/bootstrap-table/basic-table/bootstrap-basic-table.html',context)


@login_required(login_url="/login")
def sizing_table(request):
    context = {"breadcrumb":{"parent":"Bootstrap Tables", "child":"Bootstrap Table Sizes"}}
    return render(request,'table/bootstrap-table/sizing-table/bootstrap-sizing-table.html',context)


@login_required(login_url="/login")
def border_table(request):
    context = {"breadcrumb":{"parent":"Bootstrap Tables", "child":"Bootstrap Border Table "}}
    return render(request,'table/bootstrap-table/border-table/bootstrap-border-table.html',context)


@login_required(login_url="/login")
def styling_table(request):
    context = {"breadcrumb":{"parent":"Bootstrap Tables", "child":"Bootstrap Styling Tables"}}
    return render(request,'table/bootstrap-table/styling-table/bootstrap-styling-table.html',context)


@login_required(login_url="/login")
def table_components(request):
    context = {"breadcrumb":{"parent":"Bootstrap Tables", "child":"Table Components"}}
    return render(request,'table/bootstrap-table/table-components/table-components.html',context)

#------------------------data table

@login_required(login_url="/login")
def datatable_basic_init(request):
    context = {"breadcrumb":{"parent":"Data Tables", "child":"Basic DataTables"}}
    return render(request,'table/data-table/datatable-basic/datatable-basic-init.html',context)


@login_required(login_url="/login")
def datatable_advance(request):
    context = {"breadcrumb":{"parent":"Data Tables", "child":"Advanced DataTables"}}
    return render(request,'table/data-table/datatable-advance/datatable-advance.html',context)


@login_required(login_url="/login")
def datatable_styling(request):
    context = {"breadcrumb":{"parent":"Data Tables", "child":"Styling DataTables"}}
    return render(request,'table/data-table/datatable-styling/datatable-styling.html',context)


@login_required(login_url="/login")
def datatable_AJAX(request):
    context = {"breadcrumb":{"parent":"Data Tables", "child":"Ajax DataTables"}}
    return render(request,'table/data-table/datatable-AJAX/datatable-AJAX.html',context)


@login_required(login_url="/login")
def datatable_server_side(request):
    context = {"breadcrumb":{"parent":"Data Tables", "child":"Datatables Server Side"}}
    return render(request,'table/data-table/datatable-server/datatable-server-side.html',context)


@login_required(login_url="/login")
def datatable_plugin(request):
    context = {"breadcrumb":{"parent":"Data Tables", "child":"Plugin DataTable"}}
    return render(request,'table/data-table/datatable-plugin/datatable-plugin.html',context)
    

@login_required(login_url="/login")
def datatable_API(request):
    context = {"breadcrumb":{"parent":"Data Tables", "child":"API DataTables"}}
    return render(request,'table/data-table/datatable-API/datatable-API.html',context)
    

@login_required(login_url="/login")
def datatable_data_source(request):
    context = {"breadcrumb":{"parent":"Data Tables", "child":"DATA Source DataTables"}}
    return render(request,'table/data-table/data-source/datatable-data-source.html',context)


#-------------------------------EX.data-table

@login_required(login_url="/login")
def ext_autofill(request):
    context = {"breadcrumb":{"parent":"Extension Data Tables", "child":"Autofill Datatables"}}
    return render(request,'table/Ex-data-table/ext-autofill/datatable-ext-autofill.html',context)


@login_required(login_url="/login")
def ext_basic_button(request):
    context = {"breadcrumb":{"parent":"Extension Data Tables", "child":"Basic Button"}}    
    return render(request,'table/Ex-data-table/basic-button/datatable-ext-basic-button.html',context)


@login_required(login_url="/login")
def ext_col_reorder(request):
    context = {"breadcrumb":{"parent":"Extension Data Tables", "child":"Columns Reorder"}}    
    return render(request,'table/Ex-data-table/col-reorder/datatable-ext-col-reorder.html',context)


@login_required(login_url="/login")
def ext_fixed_header(request):
    context = {"breadcrumb":{"parent":"Extension Data Tables", "child":"Fixed Columns"}}    
    return render(request,'table/Ex-data-table/fixed-header/datatable-ext-fixed-header.html',context)


@login_required(login_url="/login")
def ext_html_5_data_export(request):
    context = {"breadcrumb":{"parent":"Extension Data Tables", "child":"HTML 5 Data Export"}}   
    return render(request,'table/Ex-data-table/html-export/datatable-ext-html-5-data-export.html',context)


@login_required(login_url="/login")
def ext_key_table(request):
    context = {"breadcrumb":{"parent":"Extension Data Tables", "child":"Key Table"}}    
    return render(request,'table/Ex-data-table/key-table/datatable-ext-key-table.html',context)


@login_required(login_url="/login")
def ext_responsive(request):
    context = {"breadcrumb":{"parent":"Extension Data Tables", "child":"Responsive Datatables"}}    
    return render(request,'table/Ex-data-table/ext-responsive/datatable-ext-responsive.html',context)
    

@login_required(login_url="/login")
def ext_row_reorder(request):
    context = {"breadcrumb":{"parent":"Extension Data Tables", "child":"Rows Reorder"}}    
    return render(request,'table/Ex-data-table/row-reorder/datatable-ext-row-reorder.html',context)


@login_required(login_url="/login")
def ext_scroller(request):
    context = {"breadcrumb":{"parent":"Extension Data Tables", "child":"Scroller"}}    
    return render(request,'table/Ex-data-table/ext-scroller/datatable-ext-scroller.html',context)

#--------------------------------jsgrid_table


@login_required(login_url="/login")
def jsgrid_table(request):
    context = {"breadcrumb":{"parent":"Tables", "child":"JS Grid Tables"}}
    return render(request,'table/js-grid-table/jsgrid-table.html',context)    



#---------------------------------------------------------------------------------------------------------



@login_required(login_url="/login")
def projects(request):
    context = {"breadcrumb":{"parent":"Dashboard", "child":"Project List"}}
    return render(request,'applications/projects/projects-list/projects.html',context)    


@login_required(login_url="/login")
def projectcreate(request):
    context = {"breadcrumb":{"parent":"Apps", "child":"Project Create"}}
    return render(request,'applications/projects/projectcreate/projectcreate.html',context) 

#-------------------File Manager

@login_required(login_url="/login")
def file_manager(request):
    context = {"breadcrumb":{"parent":"Apps", "child":"File Manager"}}
    return render(request,'applications/file_manager/file-manager.html',context)   


#------------------Kanban Board

@login_required(login_url="/login")
def kanban(request):
    context = {"breadcrumb":{"parent":"Apps", "child":"Kanban Board"}}
    return render(request,'applications/kanban/kanban.html',context)  

#--------------------ecommerce


@login_required(login_url="/login")
def product_simple(request):
    context = {"breadcrumb":{"parent":"Ecommerce", "child":"Product"}}
    return render(request,'applications/ecommerce/product/product.html',context)  
  

@login_required(login_url="/login")
def product_page(request):
    context = {"breadcrumb":{"parent":"Ecommerce", "child":"Product Page"}}
    return render(request,'applications/ecommerce/product-page/product-page.html',context)  


@login_required(login_url="/login")
def list_products(request):
    context = {"breadcrumb":{"parent":"Ecommerce", "child":"Product List"}}
    return render(request,'applications/ecommerce/list-products/list-products.html',context)    


@login_required(login_url="/login")
def payment_details(request):
    context = {"breadcrumb":{"parent":"Ecommerce", "child":"Payment Details"}}
    return render(request,'applications/ecommerce/payment-details/payment-details.html',context)    


@login_required(login_url="/login")
def order_history(request):
    context = {"breadcrumb":{"parent":"Ecommerce", "child":"Recent Orders"}}
    return render(request,'applications/ecommerce/order-history/order-history.html',context)    


@login_required(login_url="/login")
def invoice_template(request):
    context = {"breadcrumb":{"parent":"Ecommerce", "child":"Invoice"}}
    return render(request,'applications/ecommerce/invoice-template/invoice-template.html',context)    


@login_required(login_url="/login")
def cart(request):
    context = {"breadcrumb":{"parent":"Ecommerce", "child":"Cart"}}
    return render(request,'applications/ecommerce/cart/cart.html',context)  


@login_required(login_url="/login")
def list_wish(request):
    context = {"breadcrumb":{"parent":"Ecommerce", "child":"Wishlist"}}
    return render(request,'applications/ecommerce/list-wish/list-wish.html',context) 


@login_required(login_url="/login")
def checkout(request):
    context = {"breadcrumb":{"parent":"Ecommerce", "child":"Checkout"}}
    return render(request,'applications/ecommerce/checkout/checkout.html',context)  


@login_required(login_url="/login")
def pricing(request):
    context = {"breadcrumb":{"parent":"Ecommerce", "child":"Pricing"}}
    return render(request,'applications/ecommerce/pricing/pricing.html',context)  

#--------------------------emails


@login_required(login_url="/login")
def email_application(request):
    context = {"breadcrumb":{"parent":"Email", "child":"Email Application"}}
    return render(request,'applications/email/email-inbox/email-application.html',context) 
  

@login_required(login_url="/login")
def email_readmail(request):
    context = {"breadcrumb":{"parent":"Email", "child":"Email Compose"}}
    return render(request,'applications/email/email-readmail/email-read-mail.html',context) 


@login_required(login_url="/login")
def email_compose(request):
    context = {"breadcrumb":{"parent":"Email", "child":"Email Compose"}}
    return render(request,'applications/email/email-compose/email-compose.html',context) 

#--------------------------------chat

@login_required(login_url="/login")
def chat(request):
    context = {"breadcrumb":{"parent":"Apps", "child":"Chat"}}
    return render(request,'applications/chat/chat/chat.html',context) 


@login_required(login_url="/login")
def chat_video(request):
    context = {"breadcrumb":{"parent":"Chat", "child":"Video Chat"}}
    return render(request,'applications/chat/chat-video/chat-video.html',context) 

#---------------------------------user

@login_required(login_url="/login")
def user_profile(request):
    context = {"breadcrumb":{"parent":"Users", "child":"User Profile"}}
    return render(request,'applications/user/user-profile/user-profile.html',context)     


@login_required(login_url="/login")
def edit_profile(request):
    context = {"breadcrumb":{"parent":"Users", "child":"Edit Profile"}}
    return render(request,'applications/user/edit-profile/edit-profile.html',context)     


@login_required(login_url="/login")
def user_cards(request):
    context = {"breadcrumb":{"parent":"Users", "child":"User Cards"}}
    return render(request,'applications/user/user-cards/user-cards.html',context)   

#------------------------bookmark

@login_required(login_url="/login")
def bookmark(request):
    context = {"breadcrumb":{"parent":"Apps", "child":"Bookmarks"}}
    return render(request,'applications/bookmark/bookmark.html',context)  

#------------------------contacts

@login_required(login_url="/login")
def contacts(request):
    context = {"breadcrumb":{"parent":"Apps", "child":"Contacts"}}
    return render(request,'applications/contacts/contacts.html',context) 

#------------------------task

@login_required(login_url="/login")
def task(request):
    context = {"breadcrumb":{"parent":"Apps", "child":"Tasks"}}
    return render(request,'applications/task/task.html',context)

#------------------------calendar

@login_required(login_url="/login")
def calendar_basic(request):
    context = {"breadcrumb":{"parent":"Apps", "child":"Calender Basic"}}
    return render(request,'applications/calendar/calendar-basic.html',context)

#------------------------social-app

@login_required(login_url="/login")
def social_app(request):
    context = {"breadcrumb":{"parent":"Apps", "child":"Social App"}}
    return render(request,'applications/social-app/social-app.html',context)

#------------------------to-do

@login_required(login_url="/login")
def to_do_html(request):
    context = {"breadcrumb":{"parent":"Apps", "child":"To-Do"}}
    return render(request,'applications/to-do/to-do.html',context)  

#------------------------search

@login_required(login_url="/login")
def search(request):
    context = {"breadcrumb":{"parent":"Search Pages", "child":"Search Website"}}
    return render(request,'applications/search/search.html',context)

  

#--------------Pages


@login_required(login_url="/login")
def landing_page(request):
    return render(request,'pages/landing-page/landing-page.html')


@login_required(login_url="/login")
def sample_page(request):
    context = {"breadcrumb":{"parent":"Pages", "child":"Sample Page"}}
    return render(request,'pages/sample-page/sample-page.html',context)


@login_required(login_url="/login")
def internationalization(request):
    context = {"breadcrumb":{"parent":"pages", "child":"Internationalization"}}
    return render(request,'pages/internationalization/internationalization.html',context)   


#------------------starter-kit


@login_required(login_url="/login")
def starter_kit(request):
    return render(request,'pages/starter-kit/starter-kit.html')

@login_required(login_url="/login")
def starterkit_boxed(request):
    context = {"layout":"box-layout"}
    return render(request,'pages/starter-kit/boxed.html',context)

@login_required(login_url="/login")
def starterkit_footer_dark(request):
    context ={"footer":"footer-dark"}
    return render(request,'pages/starter-kit/footer-dark.html',context)

@login_required(login_url="/login")
def starterkit_footer_fixed(request):
    context ={"footer":"footer-fix"}
    return render(request,'pages/starter-kit/footer-fixed.html',context)

@login_required(login_url="/login")
def starterkit_footer_light(request):
    return render(request,'pages/starter-kit/footer-light.html')

@login_required(login_url="/login")
def starterkit_layout_dark(request):
    context={"layout":"dark-only"}
    return render(request,'pages/starter-kit/layout-dark.html',context)

@login_required(login_url="/login")
def starterkit_layout_rtl(request):
    context = {"layout":"rtl"}

    return render(request,'pages/starter-kit/layout-rtl.html',context)

#-----------------------------------------------others

#------------------------------error page


@login_required(login_url="/login")
def error_page1(request):
    return render(request,'pages/others/error-page/error-page/error-page1.html')

@login_required(login_url="/login")
def error_page2(request):
    return render(request,'pages/others/error-page/error-page/error-page2.html')

@login_required(login_url="/login")
def error_page3(request):
    return render(request,'pages/others/error-page/error-page/error-page3.html')


@login_required(login_url="/login")
def error_page4(request):
    return render(request,'pages/others/error-page/error-page/error-page4.html')

def logout_view(request):
    print('In logout up', request.method)
    if request.method == 'POST':
        print('In logout')
        logout(request)
        return redirect('login')
    else:
        return redirect('login')


def loginview(request):
      if request.method == 'POST':
        form = AuthenticationForm(data=request.POST)
        if form.is_valid():
            # log the user in
            user = form.get_user()
            print('user', user)
            login(request, user)
            if 'next' in request.POST:
                print("krupa",request.POST.get('next'))
                return HttpResponseRedirect(request.POST.get('next'))
            else:
               return redirect('ecommerce')
      else:
            form = AuthenticationForm()
      return render(request, 'pages/others/authentication/login/login.html', {'form': form })

@login_required(login_url="/login")
def login_one(request):
    return render(request,'pages/others/authentication/login-one/login-one.html')


@login_required(login_url="/login")
def login_two(request):
    return render(request,'pages/others/authentication/login-two/login-two.html')


@login_required(login_url="/login")
def login_bs_validation(request):
    return render(request,'pages/others/authentication/login-bs-validation/login-bs-validation.html')


@login_required(login_url="/login")
def login_tt_validation(request):
    return render(request,'pages/others/authentication/login-bs-tt-validation/login-bs-tt-validation.html')


@login_required(login_url="/login")
def login_validation(request):
    return render(request,'pages/others/authentication/login-sa-validation/login-sa-validation.html')


# @login_required(login_url="/login")# 
# def sign_up(request):
#     return render(request,'pages/others/authentication/sign-up/sign-up.html')


def sign_up(request):
    if request.method == 'POST':
         form = UserCreationForm(request.POST)
         if form.is_valid():
             user = form.save()
             #  log the user in
             login(request, user)
             return redirect('default')
    else:
        form = UserCreationForm()
    return render(request, 'pages/others/authentication/sign-up/sign-up.html', { 'form': form })


@login_required(login_url="/login")
def sign_one(request):
    return render(request,'pages/others/authentication/sign-one/sign-up-one.html')


@login_required(login_url="/login")
def sign_two(request):
    return render(request,'pages/others/authentication/sign-two/sign-up-two.html')


@login_required(login_url="/login")
def sign_wizard(request):
    return render(request,'pages/others/authentication/sign-up-wizard/sign-up-wizard.html')    


@login_required(login_url="/login")
def unlock(request):
    return render(request,'pages/others/authentication/unlock/unlock.html')


@login_required(login_url="/login")
def forget_password(request):
    return render(request,'pages/others/authentication/forget-password/forget-password.html')


@login_required(login_url="/login")
def creat_password(request):
    return render(request,'pages/others/authentication/creat-password/creat-password.html')


@login_required(login_url="/login")
def maintenance(request):
    return render(request,'pages/others/authentication/maintenance/maintenance.html')


#---------------------------------------comingsoon


@login_required(login_url="/login")
def comingsoon(request):
    return render(request,'pages/others/comingsoon/comingsoon/comingsoon.html')
    

@login_required(login_url="/login")
def comingsoon_video(request):
    return render(request,'pages/others/comingsoon/comingsoon-video/comingsoon-bg-video.html')
    

@login_required(login_url="/login")
def comingsoon_img(request):
    return render(request,'pages/others/comingsoon/comingsoon-img/comingsoon-bg-img.html')

#----------------------------------Email-Template

@login_required(login_url="/login")
def basic_temp(request):
    return render(request,'pages/others/email-templates/basic-email/basic-template.html')


@login_required(login_url="/login")
def email_header(request):
    return render(request,'pages/others/email-templates/basic-header/email-header.html')


@login_required(login_url="/login")
def template_email(request):
    return render(request,'pages/others/email-templates/ecom-template/template-email.html')


@login_required(login_url="/login")
def template_email_2(request):
    return render(request,'pages/others/email-templates/template-email-2/template-email-2.html')


@login_required(login_url="/login")
def ecommerce_temp(request):
    return render(request,'pages/others/email-templates/ecom-email/ecommerce-templates.html')


@login_required(login_url="/login")
def email_order(request):
    return render(request,'pages/others/email-templates/order-success/email-order-success.html')       

#------------------------------------------ Miscellaneous ----------------- -------------------------

#--------------------------------------gallery

@login_required(login_url="/login")
def gallery_grid(request):
    context = {"breadcrumb":{"parent":"Gallery", "child":"Gallery   "}}    
    return render(request,'miscellaneous/gallery/gallery-grid/gallery.html',context)


@login_required(login_url="/login")
def grid_description(request):
    context = {"breadcrumb":{"parent":"Gallery", "child":"Gallery Grid With Description"}}    
    return render(request,'miscellaneous/gallery/gallery-grid-desc/gallery-with-description.html',context)


@login_required(login_url="/login")
def masonry_simple(request):
    context = {"breadcrumb":{"parent":"Gallery", "child":"Masonry Gallery"}}    
    return render(request,'miscellaneous/gallery/masonry-gallery/gallery-masonry.html',context)


@login_required(login_url="/login")
def masonry_disc(request):
    context = {"breadcrumb":{"parent":"Gallery", "child":"Masonry Gallery With Description"}}    
    return render(request,'miscellaneous/gallery/masonry-with-desc/masonry-gallery-with-disc.html',context)


@login_required(login_url="/login")
def hover(request):
    context = {"breadcrumb":{"parent":"Gallery", "child":"Hover Effects"}}    
    return render(request,'miscellaneous/gallery/hover-effects/gallery-hover.html',context)

#------------------------------------Blog

@login_required(login_url="/login")
def blog_simple(request):  
    context = {"breadcrumb":{"parent":"Blog", "child":"Blog Details"}}    
    return render(request,'miscellaneous/blog/blog-details/blog.html',context)


@login_required(login_url="/login")
def blog_single(request):
    context = {"breadcrumb":{"parent":"Blog", "child":"Blog Single"}}    
    return render(request,'miscellaneous/blog/blog-single/blog-single.html',context)


@login_required(login_url="/login")
def add_post(request):
    context = {"breadcrumb":{"parent":"Blog", "child":"Add Post"}}    
    return render(request,'miscellaneous/blog/add-post/add-post.html',context)

#-------------------------faq

@login_required(login_url="/login")
def FAQ(request):
    context = {"breadcrumb":{"parent":"FAQ", "child":"FAQ"}}    
    return render(request,'miscellaneous/FAQ/faq.html',context)

#---------------------------------job serach

@login_required(login_url="/login")
def job_cards(request):
    context = {"breadcrumb":{"parent":"Job Search", "child":"Cards View"}}    
    return render(request,'miscellaneous/job-search/cards-view/job-cards-view.html',context)


@login_required(login_url="/login")
def job_list(request):
    context = {"breadcrumb":{"parent":"Job Search", "child":"List View"}}    
    return render(request,'miscellaneous/job-search/list-view/job-list-view.html',context)


@login_required(login_url="/login")
def job_details(request):
    context = {"breadcrumb":{"parent":"Job Search", "child":"Job Details"}}    
    return render(request,'miscellaneous/job-search/job-details/job-details.html',context)


@login_required(login_url="/login")
def apply(request):
    context = {"breadcrumb":{"parent":"Job Search", "child":"Apply"}}    
    return render(request,'miscellaneous/job-search/apply/job-apply.html',context)

#------------------------------------Learning

@login_required(login_url="/login")
def learning_list(request):
    context = {"breadcrumb":{"parent":"Learning", "child":"Learning List"}}    
    return render(request,'miscellaneous/learning/learning-list/learning-list-view.html',context)
    

@login_required(login_url="/login")
def learning_detailed(request):
    context = {"breadcrumb":{"parent":"Learning", "child":"Detailed Course"}}    
    return render(request,'miscellaneous/learning/learning-detailed/learning-detailed.html',context)    

#----------------------------------------Maps

@login_required(login_url="/login")
def maps_js(request):
    context = {"breadcrumb":{"parent":"Maps", "child":"Map JS"}}    
    return render(request,'miscellaneous/maps/maps-js/map-js.html',context)


@login_required(login_url="/login")
def vector_maps(request):
    context = {"breadcrumb":{"parent":"Maps", "child":"Vector Maps"}}
    return render(request,'miscellaneous/maps/vector-maps/vector-map.html',context)    

#------------------------------------Editors

@login_required(login_url="/login")
def summernote(request):
    context = {"breadcrumb":{"parent":"Editors", "child":"Summer Note"}}    
    return render(request,'miscellaneous/editors/summer-note/summernote.html',context)


@login_required(login_url="/login")
def ckeditor(request):
    context = {"breadcrumb":{"parent":"Editors", "child":"Ck Editor"}}    
    return render(request,'miscellaneous/editors/ckeditor/ckeditor.html',context)


@login_required(login_url="/login")
def simple_mde(request):
    context = {"breadcrumb":{"parent":"Editors", "child":"MDE Editor"}}    
    return render(request,'miscellaneous/editors/simple-mde/simple-mde.html',context) 


@login_required(login_url="/login")
def ace_code(request):
    context = {"breadcrumb":{"parent":"Editors", "child":"ACE Code Editor"}}    
    return render(request,'miscellaneous/editors/ace-code/ace-code.html',context)       

#----------------------------knowledgeUi Kits

@login_required(login_url="/login")
def knowledgebase(request):
    context = {"breadcrumb":{"parent":"KnowledgeBase", "child":"KnowledgeBase"}}    
    return render(request,'miscellaneous/knowledgebase/knowledgebase/knowledgebase.html',context)  


@login_required(login_url="/login")
def know_category(request):
    context = {"breadcrumb":{"parent":"Knowledgebase", "child":"Knowledge Category"}}    
    return render(request,'miscellaneous/knowledgebase/knowl-category/knowledge-category.html',context)


@login_required(login_url="/login")
def know_detail(request):
    context = {"breadcrumb":{"parent":"Knowledgebase", "child":"Knowledge Detail"}}    
    return render(request,'miscellaneous/knowledgebase/knowl-detail/knowledge-detail.html',context)

#-----------------------------support-ticket

@login_required(login_url="/login")
def support_ticket(request):
    context = {"breadcrumb":{"parent":"Pages", "child":"Support Ticket"}}    
    return render(request,'miscellaneous/support-ticket/support-ticket.html',context)
    

@login_required(login_url="/login")
def to_do_database(request):
    tasks = Task.objects.all()
    
    form = TaskForm()
    if request.method == "POST":
        form = TaskForm(request.POST)
        if form.is_valid():
            form.save()
        return redirect('/to_do_database')
 

    completedTasks = True
    for t in tasks:
        if t.complete == False:
            completedTasks = False

    context = {'tasks': tasks, 'form': form, 'completedTasks': completedTasks, "breadcrumb":{"parent":"Todo", "child":"Todo with database"}}

    return render(request, 'applications/to-do-database/to-do.html', context)


@login_required(login_url="/login")
def markAllComplete(request):
    allTasks = Task.objects.all()
    for oneTask in allTasks:
        oneTask.complete = True
        oneTask.save()
    return HttpResponseRedirect("/to_do_database")


@login_required(login_url="/login")
def markAllIncomplete(request):
    allTasks = Task.objects.all()
    for oneTask in allTasks:
        oneTask.complete = False
        oneTask.save()
    return HttpResponseRedirect("/to_do_database")

    

@login_required(login_url="/login")
def deleteTask(request, pk):
    item = Task.objects.get(id=pk)
    
    #if request.method == "POST":
    item.delete()
    return HttpResponseRedirect("/to_do_database")

    #return render(request, 'delete.html')


@login_required(login_url="/login")
def updateTask(request, pk):
    task = Task.objects.get(id=pk)
    if task.complete == False:
        task.complete = True
        task.save()
    else:
        task.complete = False
        task.save()

    return HttpResponseRedirect("/to_do_database")