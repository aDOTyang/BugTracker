<?php $__env->startSection('title'); ?>Box Shadow
 <?php echo e($title); ?>

<?php $__env->stopSection(); ?>

<?php $__env->startPush('css'); ?>
<?php $__env->stopPush(); ?>

<?php $__env->startSection('content'); ?>
	<?php $__env->startComponent('components.breadcrumb'); ?>
		<?php $__env->slot('breadcrumb_title'); ?>
			<h3>Box Shadow</h3>
		<?php $__env->endSlot(); ?>
		<li class="breadcrumb-item">Base</li>
		<li class="breadcrumb-item active">Box Shadow</li>
    <?php echo $__env->renderComponent(); ?>
    
    <div class="container-fluid">
        <div class="row">
            <div class="col-sm-12">
                <div class="card box-shadow-title">
                    <div class="card-header pb-0">
                        <h5>Examples</h5>
                        <span>
                            While shadows on components are disabled by default in Bootstrap and can be enabled via <code>$enable-shadows</code>, you can also quickly add or remove a shadow with our <code>box-shadow</code> utility classes.
                            Includes support for <code>.shadow-none</code> and three default sizes (which have associated variables to match).
                        </span>
                    </div>
                    <div class="card-body row">
                        <div class="col-12">
                            <h6 class="sub-title mt-0">Larger shadow</h6>
                        </div>
                        <div class="col-sm-4">
                            <div class="shadow-lg p-25 shadow-showcase text-center">
                                <h5 class="m-0 f-18">Larger shadow</h5>
                            </div>
                        </div>
                        <div class="col-sm-4">
                            <div class="shadow-lg p-25 shadow-showcase text-center">
                                <h5 class="m-0 f-18">Larger shadow</h5>
                            </div>
                        </div>
                        <div class="col-sm-4">
                            <div class="shadow-lg p-25 shadow-showcase text-center">
                                <h5 class="m-0 f-18">Larger shadow</h5>
                            </div>
                        </div>
                        <div class="col-12">
                            <h6 class="sub-title">Regular shadow</h6>
                        </div>
                        <div class="col-sm-4">
                            <div class="shadow shadow-showcase p-25 text-center">
                                <h5 class="m-0 f-18">Regular shadow</h5>
                            </div>
                        </div>
                        <div class="col-sm-4">
                            <div class="shadow shadow-showcase p-25 text-center">
                                <h5 class="m-0 f-18">Regular shadow</h5>
                            </div>
                        </div>
                        <div class="col-sm-4">
                            <div class="shadow shadow-showcase p-25 text-center">
                                <h5 class="m-0 f-18">Regular shadow</h5>
                            </div>
                        </div>
                        <div class="col-12">
                            <h6 class="sub-title">Small shadow</h6>
                        </div>
                        <div class="col-sm-4">
                            <div class="shadow-sm shadow-showcase p-25 text-center">
                                <h5 class="m-0 f-18">Small shadow</h5>
                            </div>
                        </div>
                        <div class="col-sm-4">
                            <div class="shadow-sm shadow-showcase p-25 text-center">
                                <h5 class="m-0 f-18">Small shadow</h5>
                            </div>
                        </div>
                        <div class="col-sm-4">
                            <div class="shadow-sm shadow-showcase p-25 text-center">
                                <h5 class="m-0 f-18">Small shadow</h5>
                            </div>
                        </div>
                        <div class="col-12">
                            <h6 class="sub-title">No shadow</h6>
                        </div>
                        <div class="col-sm-4">
                            <div class="shadow-none shadow-showcase p-25 text-center">
                                <h5 class="m-0 f-18">No shadow</h5>
                            </div>
                        </div>
                        <div class="col-sm-4">
                            <div class="shadow-none shadow-showcase p-25 text-center">
                                <h5 class="m-0 f-18">No shadow</h5>
                            </div>
                        </div>
                        <div class="col-sm-4">
                            <div class="shadow-sm shadow-showcase shadow-none p-25 text-center">
                                <h5 class="m-0 f-18">No shadow</h5>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>  

    <?php $__env->startPush('scripts'); ?> 
    <?php $__env->stopPush(); ?>

<?php $__env->stopSection(); ?>
<?php echo $__env->make('layouts.admin.master', \Illuminate\Support\Arr::except(get_defined_vars(), ['__data', '__path']))->render(); ?><?php /**PATH /home/prajit/Downloads/wetransfer_poco-zip_2022-07-16_0710/Viho-Laravel-8/theme/resources/views/admin/ui-kits/box-shadow.blade.php ENDPATH**/ ?>